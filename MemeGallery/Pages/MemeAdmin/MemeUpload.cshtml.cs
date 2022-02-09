using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MemeGallery.Data;
using MemeGallery.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;





namespace MemeGallery.Pages.MemeAdmin
{

    public class MemeUploadModel : PageModel

    {
        //COMMENT:static declaration of the CloudBlobClient so we can //interact with our storage service.
        static CloudBlobClient blobClient;
        //COMMENT:constant to hold the blob container name
        const string BLOB_CONTAINER_NAME = "pandemicmeme";
        //COMMENT:static declaration of CloudBlobContainer which will store //a reference to the blobcontainer that we created earlier
        static CloudBlobContainer blobContainer;
        //COMMENT:declaration of ApplicationDbContext for an instance of our //database context.
        private ApplicationDbContext _context;
        //COMMENT:setup our configuration so that we can have access to the //Azure storage connection string later.
        public IConfiguration _configuration;
        //COMMENT:This is a property for MemeGallery with a //BindPropertyAttribute. This will automatically bind the data from //the form to the properties of MemeGallery when the form is submitted. //
        [BindProperty]
        public Meme Meme { get; set; }

        public MemeUploadModel(IConfiguration configuration, ApplicationDbContext context)
        {
            _context = context;
            _configuration = configuration;
        }

            public async Task OnGetAsync()
        {
         CloudStorageAccount storageAccount = CloudStorageAccount.Parse(_configuration.GetConnectionString("AzureStorageConnectionString"));

        // COMMENT:Create a blob client for interacting with the storage //blob service.
        blobClient = storageAccount.CreateCloudBlobClient();

        //COMMENT:this gets a reference to the container that we created earlier
        blobContainer = blobClient.GetContainerReference(BLOB_CONTAINER_NAME);

        //COMMENT:this will create a container with the name that we passed //above in the event that the container doesn't exist.
        await blobContainer.CreateIfNotExistsAsync();

        //COMMENT:set permissions to public access
        await blobContainer.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
        }

        public async Task<IActionResult> OnPost(IFormCollection form)
        {
            try
            {
                //COMMENT:we are only allowing one upload, so just get the first one in the file collection.
                var file = form.Files.FirstOrDefault();

                //COMMENT:this block will store the image into the blobContainer //container
                CloudBlockBlob blob = blobContainer.GetBlockBlobReference(file?.FileName);
                blob.Properties.ContentType = file?.ContentType;
                await blob.UploadFromStreamAsync(file?.OpenReadStream());

                //COMMENT:set the url of the image that we just uploaded
                Meme.BlobURL = $"{blobContainer.StorageUri.PrimaryUri}/{file?.FileName}";

                //COMMENT:add a GalleryImage to the database and save it.
                _context.Meme.Add(Meme);
                await _context.SaveChangesAsync();

               
                //set a tempData variable to a success string. we will use this //variable after the redirect to the gallery.
                TempData["SuccessMessage"] = "Meme upload success!";


                return RedirectToPage("/MemeAdmin/MemeGallery");
            }

                //catch (Exception ex)
            catch (Exception)
            {
                return RedirectToPage("/Error");
            }
        }

    }


}
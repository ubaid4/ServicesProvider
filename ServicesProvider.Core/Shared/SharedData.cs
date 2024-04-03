using ServicesProvider.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesProvider.Core.Shared
{
    public static class SharedData
    {
        public static string DefaultCategoryImageUrl = "https://azurestorage44.blob.core.windows.net/servicesprovider/customfolder/e612c1bf-3efd-4537-9801-70806bc9e52b-icons8-home-24.png";
        public static string DefaultCoreActivityImageUrl = "https://azurestorage44.blob.core.windows.net/servicesprovider/customfolder/e612c1bf-3efd-4537-9801-70806bc9e52b-icons8-home-24.png";
        public static string DefaultServiceImageUrl = "https://azurestorage44.blob.core.windows.net/servicesprovider/customfolder/e612c1bf-3efd-4537-9801-70806bc9e52b-icons8-home-24.png";

        public static List<Category>  SeedCategories = new List<Category>()
            {
                new Category { Id=Guid.NewGuid() , Name = "Cleaning", ArabicName="Cleaning", ImageUrl=DefaultCategoryImageUrl, RenderOrder=1, Size=1, Status=1 },
                new Category { Id=Guid.NewGuid() , Name = "Repairing", ArabicName="Repairing", ImageUrl=DefaultCategoryImageUrl, RenderOrder=2, Size=1, Status=1 },
                new Category { Id=Guid.NewGuid() , Name = "Shifting", ArabicName="Shifting", ImageUrl=  DefaultCategoryImageUrl, RenderOrder=3, Size=1, Status=1 },

            };

        public static List<CoreActivity> SeedCoreActivities = new List<CoreActivity>()
            {
                new CoreActivity { Id=Guid.NewGuid(), Name = "Full Cleaning", ArabicName="Full Cleaning", ImageUrl=DefaultCoreActivityImageUrl, RenderOrder=1, Size=1, Status=1,CategoryId=SeedCategories[0].Id },
                new CoreActivity { Id=Guid.NewGuid(), Name = "Partial Cleaning", ArabicName="Partial Cleaning", ImageUrl=DefaultCoreActivityImageUrl, RenderOrder=2, Size=1, Status=1,CategoryId=SeedCategories[0].Id },

                new CoreActivity { Id=Guid.NewGuid(), Name = "Engine Repairing", ArabicName="Engine Repairing", ImageUrl=DefaultCoreActivityImageUrl, RenderOrder=3, Size=1, Status=1,CategoryId=SeedCategories[1].Id },
                new CoreActivity { Id=Guid.NewGuid(), Name = "Body Repairing", ArabicName="Body Repairing", ImageUrl=DefaultCoreActivityImageUrl, RenderOrder=4, Size=1, Status=1,CategoryId=SeedCategories[1].Id },
                new CoreActivity { Id=Guid.NewGuid(), Name = "Inner Repairing", ArabicName="Inner Repairing", ImageUrl=DefaultCoreActivityImageUrl, RenderOrder=5, Size=1, Status=1,CategoryId=SeedCategories[1].Id },

                new CoreActivity { Id=Guid.NewGuid(), Name = "HouseToHouse Shifting", ArabicName="HouseToHouse Shifting", ImageUrl=DefaultCoreActivityImageUrl, RenderOrder=6, Size=1, Status=1,CategoryId=SeedCategories[2].Id },
                new CoreActivity { Id=Guid.NewGuid(), Name = "RoadToHouse Shifting", ArabicName="RoadToHouse Shifting", ImageUrl=DefaultCoreActivityImageUrl, RenderOrder=7, Size=1, Status=1,CategoryId=SeedCategories[2].Id },

            };
        public static List<AppServices> SeedServices = new List<AppServices>()
            {
                new AppServices { Id=Guid.NewGuid(), Name = "Bike Full Cleaning", ArabicName="Bike Full Cleaning", Description="Service Description", ArabicDescription="Arabic Service Description",Price=400, ImageUrl=DefaultServiceImageUrl, RenderOrder=1, Status=1,CategoryId=SeedCategories[0].Id,CoreActivityId=SeedCoreActivities[0].Id },
                new AppServices { Id=Guid.NewGuid(), Name = "Car Full Cleaning", ArabicName="Car Full Cleaning",Description="Service Description", ArabicDescription="Arabic Service Description",Price=400, ImageUrl=DefaultServiceImageUrl, RenderOrder=2, Status=1,CategoryId=SeedCategories[0].Id,CoreActivityId=SeedCoreActivities[0].Id },


                new AppServices { Id=Guid.NewGuid(), Name = "Bike Partial Cleaning", ArabicName="Bike Partial Cleaning",Description="Service Description", ArabicDescription="Arabic Service Description",Price=400, ImageUrl=DefaultServiceImageUrl, RenderOrder=3,  Status=1,CategoryId=SeedCategories[0].Id,CoreActivityId=SeedCoreActivities[1].Id },
                new AppServices { Id=Guid.NewGuid(), Name = "Car Partial Cleaning", ArabicName="Car Partial Cleaning", Description="Service Description", ArabicDescription="Arabic Service Description",Price=400,ImageUrl=DefaultServiceImageUrl, RenderOrder=4,  Status=1,CategoryId=SeedCategories[0].Id,CoreActivityId=SeedCoreActivities[1].Id },


                new AppServices { Id=Guid.NewGuid(), Name = "Bike Engine Repairing", ArabicName="Bike Engine Repairing",Description="Service Description", ArabicDescription="Arabic Service Description",Price=400, ImageUrl=DefaultServiceImageUrl, RenderOrder=5, Status=1,CategoryId=SeedCategories[1].Id,CoreActivityId=SeedCoreActivities[2].Id },
                new AppServices { Id=Guid.NewGuid(), Name = "Car Engine Repairing", ArabicName="Car Engine Repairing",Description="Service Description", ArabicDescription="Arabic Service Description",Price=400, ImageUrl=DefaultServiceImageUrl, RenderOrder=6, Status=1,CategoryId=SeedCategories[1].Id,CoreActivityId=SeedCoreActivities[2].Id },

                new AppServices { Id=Guid.NewGuid(), Name = "Car Body Repairing", ArabicName="Car Body Repairing",Description="Service Description", ArabicDescription="Arabic Service Description",Price=400, ImageUrl=DefaultServiceImageUrl, RenderOrder=7,  Status=1,CategoryId=SeedCategories[1].Id,CoreActivityId=SeedCoreActivities[3].Id },
                new AppServices { Id=Guid.NewGuid(), Name = "Bike Body Repairing", ArabicName="Bike Body Repairing",Description="Service Description", ArabicDescription="Arabic Service Description",Price=400, ImageUrl=DefaultServiceImageUrl, RenderOrder=8,  Status=1,CategoryId=SeedCategories[1].Id,CoreActivityId=SeedCoreActivities[3].Id },

                new AppServices { Id=Guid.NewGuid(), Name = "Car Inner Repairing", ArabicName="Car Inner Repairing",Description="Service Description", ArabicDescription="Arabic Service Description",Price=400, ImageUrl=DefaultServiceImageUrl, RenderOrder=9, Status=1,CategoryId=SeedCategories[1].Id,CoreActivityId=SeedCoreActivities[4].Id },
                new AppServices {Id = Guid.NewGuid(), Name = "Jeep Inner Repairing", ArabicName = "Jeep Inner Repairing", Description = "Service Description", ArabicDescription = "Arabic Service Description", Price = 400, ImageUrl = DefaultServiceImageUrl, RenderOrder = 10, Status = 1, CategoryId = SeedCategories[1].Id, CoreActivityId = SeedCoreActivities[4].Id},
                new AppServices {Id = Guid.NewGuid(), Name = "Bike Inner Repairing", ArabicName = "Bike Inner Repairing", Description = "Service Description", ArabicDescription = "Arabic Service Description", Price = 400, ImageUrl = DefaultServiceImageUrl, RenderOrder = 11, Status = 1, CategoryId = SeedCategories[1].Id, CoreActivityId = SeedCoreActivities[4].Id},

                new AppServices {Id = Guid.NewGuid(), Name = "Car HouseToHouse Shifting", ArabicName = "Car HouseToHouse Shifting", Description = "Service Description", ArabicDescription = "Arabic Service Description", Price = 400, ImageUrl = DefaultServiceImageUrl, RenderOrder = 12, Status = 1, CategoryId = SeedCategories[2].Id, CoreActivityId = SeedCoreActivities[5].Id},
                new AppServices {Id = Guid.NewGuid(), Name = "Jeep HouseToHouse Shifting", ArabicName = "Jeep HouseToHouse Shifting", Description = "Service Description", ArabicDescription = "Arabic Service Description", Price = 400, ImageUrl = DefaultServiceImageUrl, RenderOrder = 13, Status = 1, CategoryId = SeedCategories[2].Id, CoreActivityId = SeedCoreActivities[5].Id},

                new AppServices {Id = Guid.NewGuid(), Name = "Jeep RoadToHouse Shifting", ArabicName = "Jeep RoadToHouse Shifting", Description = "Service Description", ArabicDescription = "Arabic Service Description", Price = 400, ImageUrl = DefaultServiceImageUrl, RenderOrder = 14, Status = 1, CategoryId = SeedCategories[2].Id, CoreActivityId = SeedCoreActivities[6].Id},
                new AppServices {Id = Guid.NewGuid(), Name = "Car RoadToHouse Shifting", ArabicName = "Car RoadToHouse Shifting", Description = "Service Description", ArabicDescription = "Arabic Service Description", Price = 400, ImageUrl = DefaultServiceImageUrl, RenderOrder = 15, Status = 1, CategoryId = SeedCategories[2].Id, CoreActivityId = SeedCoreActivities[6].Id},
                new AppServices {Id = Guid.NewGuid(), Name = "Bike RoadToHouse Shifting", ArabicName = "Bike RoadToHouse Shifting", Description = "Service Description", ArabicDescription = "Arabic Service Description", Price = 400, ImageUrl = DefaultServiceImageUrl, RenderOrder = 16, Status = 1, CategoryId = SeedCategories[2].Id, CoreActivityId = SeedCoreActivities[6].Id   },

            };

    }
}

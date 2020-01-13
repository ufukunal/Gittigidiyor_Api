using GittiGidiyor;
using GittiGidiyor.Application;
using GittiGidiyor.Category;
using GittiGidiyor.City;
using GittiGidiyor.Developer;
using GittiGidiyor.Product;
using GittiGidiyor.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductListing.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            AuthConfig();

            //AddProduct();

            AddProduct();

            Console.ReadLine();
        }

        static void AuthConfig()
        {
            AuthConfig config = new AuthConfig();
            config.ApiKey = "RRv3eamyfsgrzjHxK5sU8AVMGvwmdjT4";
            config.SecretKey = "cxnEXgP4MtaMJEQK";
            config.RoleName = "emelkrml";
            config.RolePass = "FZ3t8qrP3UmYqBQVpakZUyNWsFDVQf7T";
            ConfigurationManager.setAuthParameters(config);
        }

        static void GetDeveloper()
        {
            DeveloperService developerService = ServiceProvider.getDeveloperService();
            developerServiceResponse developerServiceResponse = developerService.createDeveloper("emelkrml", "53155542000Ek-", "tr");

            if (developerServiceResponse != null && developerServiceResponse.ackCode.ToString().Equals("success"))
            {
                Console.WriteLine("DeveloperId: " + developerServiceResponse.developerId);
                Console.WriteLine("Nick: " + developerServiceResponse.nick);
                Console.WriteLine("RegisterDate: " + developerServiceResponse.registerDate);
            }
            else
            {
                Console.WriteLine("Error DeveloperId");
                Console.WriteLine("Error Nick");
                Console.WriteLine("Error RegisterDate ");
            }
        }

        static void AppDetail()
        {
            ApplicationService applicationService = ServiceProvider.getApplicationService();
            applicationServiceListResponse serviceListResponse = applicationService.getApplicationList("Ck7VUH8TmRY9UhJyyuCd", "tr");

            if (serviceListResponse != null && serviceListResponse.ackCode.ToString().Equals("success"))
            {
                Console.WriteLine("Application Count: " + serviceListResponse.applicationCount);
                Console.WriteLine("\n\n");

                applicationType[] applist = serviceListResponse.applications;

                foreach (applicationType application in applist)
                {
                    Console.WriteLine("Api Key: " + application.apiKey);
                    Console.WriteLine("Secret Key: " + application.secretKey);
                    Console.WriteLine("ApplicationName: " + application.name);
                    Console.WriteLine("AplicationType: " + application.applicationType1);
                    Console.WriteLine("AccessType: " + application.accessType);
                    Console.WriteLine("Description: " + application.description);
                    Console.WriteLine("RegisterDate: " + application.registerDate);
                    Console.WriteLine("DescDetail: " + application.descDetail);
                    Console.WriteLine("successReturnUrl: " + application.successReturnUrl);
                    Console.WriteLine("failReturnUrl: " + application.failReturnUrl);
                }
            }
            else
            {
                Console.WriteLine("ErrorId: " + serviceListResponse.error.errorId);
                Console.WriteLine("ErrorCode: " + serviceListResponse.error.errorCode);
                Console.WriteLine("ErrorMessage: " + serviceListResponse.error.message);
            }
        }

        static void GetProduct()
        {
            ProductService productService = ServiceProvider.getProductService();
            productServiceListResponse serviceListResponse = productService.getProducts(0, 5, "L", true, "tr");

            if (serviceListResponse != null && serviceListResponse.ackCode.ToString().Equals("success"))
            {
                Console.WriteLine("Products Count: " + serviceListResponse.productCount + "\n");

                productDetailType[] productDetails = serviceListResponse.products;
                foreach (productDetailType productDetail in productDetails)
                {
                    Console.WriteLine("ProductId: " + productDetail.productId);
                    Console.WriteLine("CategoryCode: " + productDetail.product.categoryCode);
                    Console.WriteLine("Title: " + productDetail.product.title);
                    Console.WriteLine("Format: " + productDetail.product.format);
                    Console.WriteLine("Descriiption: " + productDetail.product.description);
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("ErrorId: " + serviceListResponse.error.errorId);
                Console.WriteLine("ErrorCode: " + serviceListResponse.error.errorCode);
                Console.WriteLine("ErrorMessage: " + serviceListResponse.error.message);
            }
        }

        static void AddProduct()
        {
            ProductService productService = ServiceProvider.getProductService();
            productType product = new productType();
            product.categoryCode = "aaa";
            product.title = "Test Ürünüdür";

            specType brandSpec = new specType();
            brandSpec.name = "Marka";
            brandSpec.type = "Combo";
            brandSpec.value = "Nokia";
            brandSpec.required = true;
            specType modelSpec = new specType();
            modelSpec.name = "Model";
            modelSpec.type = "Combo";
            modelSpec.value = "N73";
            modelSpec.required = true;
            specType statusSpec = new specType();
            statusSpec.name = "Durumu";
            statusSpec.type = "Combo";
            statusSpec.value = "Sıfır";
            statusSpec.required = true;
            specType guaranteeSpec = new specType();
            guaranteeSpec.name = "Garantisi";
            guaranteeSpec.type = "Combo";
            guaranteeSpec.value = "Yok";
            guaranteeSpec.required = true;
            specType[] specTypeArray = new specType[4];
            specTypeArray[0] = brandSpec;
            specTypeArray[1] = modelSpec;
            specTypeArray[2] = statusSpec;
            specTypeArray[3] = guaranteeSpec;
            product.specs = specTypeArray;

            // set ProductPhoto
            photoType photo = new photoType();
            photo.photoId = 0;
            photo.photoIdSpecified = true;
            photo.url = "http://img2.blogcu.com/images/o/r/g/orgudunyam1/cilek.jpg";
            photoType[] photoTypeArray = new photoType[1];
            photoTypeArray[0] = photo;
            product.photos = photoTypeArray;

            product.pageTemplate = 1;
            product.pageTemplateSpecified = true;
            product.description = "Test ürünü açıklaması";
            product.format = "S";
            //product.startPrice = 3.50;
            //product.startPriceSpecified = true;
            product.buyNowPrice = 49.50;
            product.buyNowPriceSpecified = true;
            product.listingDays = 30;
            product.listingDaysSpecified = true;
            product.productCount = 1;
            product.productCountSpecified = true;

            // set CargoDetail
            cargoDetailType cargoDetail = new cargoDetailType();
            cargoDetail.city = "34";
            String[] cargoCompany = new String[3];
            cargoCompany[0] = "aras";
            cargoCompany[1] = "mng";
            cargoDetail.cargoCompanies = cargoCompany;
            cargoCompanyDetailType cargoCompanyDetailType = new cargoCompanyDetailType();
            cargoCompanyDetailType.cityPrice = "3.00";
            cargoCompanyDetailType.countryPrice = "5.00";
            cargoDetail.shippingPayment = "B";
            cargoDetail.shippingWhere = "city";
            product.cargoDetail = cargoDetail;

            product.affiliateOption = false;
            product.boldOption = false;
            product.catalogOption = false;
            product.vitrineOption = false;
            product.startDate = "2020-02-13 00:00:00";
            

            productServiceResponse response = productService.insertProduct("pc", product, true, false, "tr");
            if (response != null && response.ackCode.ToString().Equals("success"))
            {
                Console.WriteLine("Result: " + response.result);
                Console.WriteLine("ProductId: " + response.productId);
            }
            else
            {
                Console.WriteLine("ErrorId: " + response.error.errorId);
                Console.WriteLine("ErrorCode: " + response.error.errorCode);
                Console.WriteLine("ErrorMessage: " + response.error.message);
            }
        }

        static void GetCategory()
        {
            CategoryService categoryService = ServiceProvider.getCategoryService();
            categoryServiceResponse response = categoryService.getCategory("th", true, true, true, "tr");

            if (response != null && response.ackCode.ToString().Equals("success"))
            {
                categoryType[] category = response.categories;
                foreach (categoryType categories in category)
                {
                    Console.WriteLine("CategoryCode: " + categories.categoryCode);
                    Console.WriteLine("CategoryName: " + categories.categoryName);
                    Console.WriteLine("Deepest: " + categories.deepest);
                    Console.WriteLine("Katalog: " + categories.hasCatalog);

                    categorySpecType[] specTypes = categories.specs;
                    foreach (categorySpecType spec in specTypes)
                    {
                        Console.WriteLine("SpecName: " + spec.name);
                        Console.WriteLine("SpecType: " + spec.type);

                        String[] specValue = spec.values;
                        foreach (String specValues in specValue)
                        {
                            Console.WriteLine(specValues);
                        }
                        Console.WriteLine("\n");
                    }
                }
            }
            else
            {
                Console.WriteLine("ErrorId: " + response.error.errorId);
                Console.WriteLine("ErrorCode: " + response.error.errorCode);
                Console.WriteLine("ErrorMessage: " + response.error.message);
            }
        }

        // productId=1001 e göre
        static void UpdateStock()
        {
            ProductService productService = ServiceProvider.getProductService();
            productServiceResponse response = productService.updateStock("1001", "", 5, false, "tr");
            if (response != null && response.ackCode.ToString().Equals("success"))
            {
                Console.WriteLine("Result: " + response.result);
                Console.WriteLine("ProductId: " + response.productId);
            }
            else
            {
                Console.WriteLine("ErrorId: " + response.error.errorId);
                Console.WriteLine("ErrorCode: " + response.error.errorCode);
                Console.WriteLine("ErrorMessage: " + response.error.message);
            }
        }

        static void UpdatePrice()
        {

        }

        static void Search()
        {
            SearchService searchService = ServiceProvider.getSearchService();
            searchCriteriaType searchCriteria = new searchCriteriaType();
            searchCriteria.format = "F";
            searchCriteria.freeShipping = false;
            searchCriteria.startFromOneTL = false;
            searchCriteria.catalogOption = true;
            searchCriteria.newProduct = false;
            searchCriteria.minPrice = 179.0;
            searchCriteria.minPriceSpecified = true;
            searchCriteria.maxPrice = 190.0;
            searchCriteria.maxPriceSpecified = true;
            searchCriteria.city = 34;
            searchCriteria.seller = "magicway";
            categorySpecCriteriaType categorySpec = new categorySpecCriteriaType();
            categorySpec.name = "Markalar";
            categorySpec.value = "Tommy Hilfiger";
            categorySpecCriteriaType[] categorySpecs = new categorySpecCriteriaType[1];
            categorySpecs[0] = categorySpec;
            searchCriteria.categorySpecs = categorySpecs;
            searchCriteria.finishedItems = 15;
            searchCriteria.finishedItemsSpecified = true;
            searchServiceResponse searchServiceResponse = searchService.search("Original", searchCriteria, 0, 5, false, true, "RI", "tr");
            if (searchServiceResponse != null && searchServiceResponse.ackCode.ToString().Equals("success"))
            {
                Console.WriteLine("Ürün sayısı: " + searchServiceResponse.count + "\n");
                searchResultType[] searchResultTypes = searchServiceResponse.products;
                foreach (searchResultType products in searchResultTypes)
                {
                    Console.WriteLine("ProductId: " + products.productId);
                    Console.WriteLine("Imaj link: " + products.imageLink);
                    Console.WriteLine("Url: " + products.url);
                    Console.WriteLine("Ürün Bşalığı: " + products.title);
                    Console.WriteLine("Satıcı: " + products.seller);
                    Console.WriteLine("Ütün formatı: " + products.format);
                    Console.WriteLine("Hemen Al Fiyatı: " + products.buyNowPrice);
                }
            }
            else
            {
                Console.WriteLine("Ürün bulunamadı.");
            }
        }
    }
}

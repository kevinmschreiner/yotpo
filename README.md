# Yotpo.Light
This is Yotpo.Light, a .Net Framework client implementation for the YOTPO API. Each section of the Yotpo API can be interacted with using a Client for that specific data.

For example the Reviews Service interacts with the Reviews data, and the Groups service interacts with the Product Groups. 

## Usage
To make the utilization simple, here is a brief example of the usage.

```c#

string clientId = "YOUR CLIENT ID HERE";
clientSecret = "YOUR SECRET HERE";

//Get the list of all groups in the account
var client = new Yotpo.Light.Services.Group(clientId, clientSecret);
var results = client.Retrieve();

//The group you want to create
var key = "Test";

//loop through the results, if the result is equal to the key you want to create
if (results!=null && results.Count>0 && results.Any(x => x.display_name == key.ToLower()))
{
    //get the detail of that group
    var detail = client.Retrieve(key.ToLower());

    //get the list of products assigned to that entry
    List<string> removal = detail.products_apps.Select(x => x.sku).ToList();
    if (removal.Count > 0)
    {
        //clear all the products from the group
        var cleared = client.Products_Remove(key.ToLower(), removal);
    }
    
    //delete the group
    var deleted = client.Delete(key.ToLower());
}

//create the new gfroup
if (client.Create(key))
{
    //add the product 5001 and 5002 to the group
    var b1 = client.Products_Add(key.ToLower(), "5001");
    var b2 = client.Products_Add(key.ToLower(), "5002");

    //retrieve the group to verify
    var detail = client.Retrieve(key.ToLower());

    //If the group contains 5001, remove 5001.
    if (detail.products_apps!=null && detail.products_apps.Any(x=>x.sku=="5001")) client.Products_Remove(key.ToLower(), "5001");

    //retrieve the group again to verify
    detail = client.Retrieve(key.ToLower());

    //If the group contains 5002, remove it.
    if (detail.products_apps != null && detail.products_apps.Any(x => x.sku == "5002")) client.Products_Remove(key.ToLower(), "5002");
}

//Get the review client
var rclient = new Yotpo.Light.Services.Review(clientId, clientSecret);
//Get the bottom line, bottom lines, and bottom line by specific product
var bl = rclient.Retrieve_BottomLine();
var bls = rclient.Retrieve_BottomLines();
var blp = rclient.Retrieve_BottomLine_ByProduct("5001");

//Get the reviews by product
var rp = rclient.Retrieve_ByProduct("5001");

//Get the User and Detail of the first review.
var rpentry = rp.reviews[0];
var rp2 = rclient.Retrieve_ByUser(rpentry.user.user_id.ToString());
var rpd = rclient.Retrieve_ById(rpentry.id.ToString());

//Get the Product client
var pclient = new Yotpo.Light.Services.Product(clientId, clientSecret);
var paging = true;
var noreviews = new List<Models.Product.ProductListItem>();
int page = 0;

//Loop through the product list, identifying all the products that have no reviews.
while (paging)
{
    page += 1;
    var products = pclient.Retrieve(100,page);
    if (products.products == null || products.products.Count == 0) paging = false;
    else
    {
        foreach (var product in products.products.Where(x => x.total_reviews == 0))
        {
            noreviews.Add(product);
        }
    }
}
```

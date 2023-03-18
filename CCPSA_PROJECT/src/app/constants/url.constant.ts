import { environment } from "src/environments/environment";
let pathBase:string = environment.ipBackEndServices;
export const URL_BASE_SERVICES ={
    "PriceCheckerGetProductUrl":pathBase+"/api/PriceChecker/GetProducto/",
    "PriceCheckerGetAllPublicityBUrl":pathBase+"/api/PriceChecker/GetAllPublicityBanners",
}
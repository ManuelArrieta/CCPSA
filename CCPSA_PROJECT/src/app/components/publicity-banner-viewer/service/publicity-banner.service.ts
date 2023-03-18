import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { URL_BASE_SERVICES } from 'src/app/constants/url.constant';
import { ResponseOfRequest } from 'src/app/model/response-of-request.model';

@Injectable({
  providedIn: 'root'
})
export class PublicityBannerService {
  /*public images = 
  [
    '../../../assets/banners/banner1.jpg',
    '../../../assets/banners/banner2.jpg',
    '../../../assets/banners/banner3.jpg',
  ]*/
  constructor(private httpClient:HttpClient)
  {}

  public getPublicityBanners():Observable<any>
  {
    return this.httpClient.get(URL_BASE_SERVICES.PriceCheckerGetAllPublicityBUrl);
  }
  /*public getRandomIndexBannerFromAssets():string
  {
    
    this.
    let rand_index = Math.floor(Math.random() * (this.images.length)); 
    return this.images[rand_index]
  }*/
}

import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { URL_BASE_SERVICES } from 'src/app/constants/url.constant';

@Injectable({
  providedIn: 'root'
})
export class PriceCheckerService {
  
  constructor(private httpClient:HttpClient){}

  public getProductByBarCode(barCode:string):Observable<any>
  {
    return this.httpClient.get(URL_BASE_SERVICES.PriceCheckerGetProductUrl+barCode)
  }
}

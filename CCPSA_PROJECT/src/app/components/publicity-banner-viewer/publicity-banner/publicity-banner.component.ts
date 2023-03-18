import { Component, OnDestroy, OnInit } from '@angular/core';
import { from,interval, Observable, of, Subscription, timer } from 'rxjs';
import { PublicityBannerService } from 'src/app/components/publicity-banner-viewer/service/publicity-banner.service';
import { ResponseOfRequest } from 'src/app/model/response-of-request.model';
import Swal from 'sweetalert2';
import { Banner } from './model/Banner.model';

@Component({
  selector: 'publicity-banner',
  templateUrl: './publicity-banner.component.html',
  styleUrls: ['./publicity-banner.component.scss']
})
export class PublicityBannerComponent implements OnInit, OnDestroy {

  public image:any;
  public intervalImage:Observable<number> =interval(5000);
  private subscriptionIntervalImage:Subscription | undefined;

  public banners:Banner[] = [];

  constructor(private publicityBannerService:PublicityBannerService)
  {

  }

  ngOnInit(): void 
  {
    this.publicityBannerService.getPublicityBanners().subscribe(
      (response:ResponseOfRequest)=>
      {
        if(!response.success)
        {
          Swal.fire({
            position: 'center',
            icon: 'error',
            title: '¡Problema al cargar los banners!',
            showConfirmButton: false,
            timer: 1500
          });
        }

        if(response.success)
        {
          this.banners = <Banner[]>response.data;          
        }
      }
    );
    this.subscriptionIntervalImage = this.intervalImage.subscribe(
      ()=>
      {
        let rand_index = Math.floor(Math.random() * (this.banners.length)); 
        this.image= this.banners[rand_index].imagen;               
      }
    );
  }

  ngOnDestroy(): void {
    this.subscriptionIntervalImage?.unsubscribe();
  }

}

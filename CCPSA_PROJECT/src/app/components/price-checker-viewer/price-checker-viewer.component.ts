import { Component, OnInit, AfterViewChecked, AfterContentChecked, HostListener, ViewChild, ElementRef, OnDestroy } from '@angular/core';
import * as $ from "jquery"
import { URL_BASE_SERVICES } from 'src/app/constants/url.constant';
import { PriceCheckerService } from 'src/app/components/price-checker-viewer/service/price-checker.service';
import Swal from 'sweetalert2';
import { ResponseOfRequest } from 'src/app/model/response-of-request.model';
import { Producto } from './model/Producto';
import { interval, Observable, Subscriber } from 'rxjs';

@Component({
  selector: 'price-checker-viewer',
  templateUrl: './price-checker-viewer.component.html',
  styleUrls: ['./price-checker-viewer.component.scss']
})
export class PriceCheckerViewerComponent implements OnInit, OnDestroy{  
  
  public nombreProducto:any = 'Producto';
  public precioProducto:any = 0;

  public barcodeInput:any;

  private $interval = interval(2000);

  constructor(
    private priceCheckerService:PriceCheckerService
  )
  {
    addEventListener('paste', (event:any) =>
    {                  
      event.stopPropagation();  
      event.preventDefault();      
      //console.log(event.clipboardData.getData('text/plain')); 
      this.pasteBarcode(event.clipboardData.getData('text/plain'))
    });

    this.$interval.subscribe(()=>
    {
      if(!$("#barcodeInput").is(":focus"))
      {
        console.log("No esta focus");
        $("#barcodeInput").select().focus();
      }      
    });
  }
  ngOnDestroy(): void {
    
  }
  
  ngOnInit(): void 
  {
    $("#barcodeInput").select().focus();
  }

  private pasteBarcode(barcode:string):void
  {
    let barcode_cast:number = parseInt(barcode);
    
    if(barcode_cast.toString()==='NaN')
    {           
      Swal.fire({
        position: 'center',
        icon: 'error',
        title: '¡Codigo de barras invalido!',
        showConfirmButton: false,
        timer: 1500
      });
    }
    else
    {     
       this.barcodeInput = barcode;
      this.getProductByBarCode(barcode);
    }
    
    
  }

  public changePrice()
  {
    let barcode_cast:number = parseInt(this.barcodeInput);  
    
    if(barcode_cast.toString()==='NaN')
    {           
      Swal.fire({
        position: 'center',
        icon: 'error',
        title: '¡Codigo de barras invalido!',
        showConfirmButton: false,
        timer: 1500
      });
    }
    else
    {      
      this.getProductByBarCode(this.barcodeInput);
    }
    
  }

  /********************** SERVICES *****************************/
  private getProductByBarCode(barcode:string):void
  {
    this.priceCheckerService.getProductByBarCode(barcode).subscribe(
      (response:ResponseOfRequest)=>
      {

        if(!response.success)
        {
          Swal.fire({
            position: 'center',
            icon: 'error',
            title: '¡Problemas en el servidor!',
            showConfirmButton: false,
            timer: 1500
          });
        }

        if(response.success && response.data==null)
        {
          Swal.fire({
            position: 'center',
            icon: 'warning',
            title: '¡El producto no existe en la base de datos!',
            showConfirmButton: false,
            timer: 1500
          });
        }

        if(response.success && response.data!==null)
        {
          let producto:Producto = <Producto> response.data;          
          
          if(producto.precio) this.precioProducto = parseFloat(producto.precio);

          this.nombreProducto = producto.descripcion;          
        }                                
      },
      (error)=>{},
      ()=>{this.barcodeInput=undefined}
    );
  }

}

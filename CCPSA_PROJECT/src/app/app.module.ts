import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PriceCheckerViewerComponent } from './components/price-checker-viewer/price-checker-viewer.component';
import { PublicityBannerComponent } from './components/publicity-banner-viewer/publicity-banner/publicity-banner.component';
import {MatCardModule} from '@angular/material/card';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatInputModule} from '@angular/material/input';
import { FormsModule } from '@angular/forms';
import { PriceCheckerService } from './components/price-checker-viewer/service/price-checker.service';
import {HttpClientModule} from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    PriceCheckerViewerComponent,
    PublicityBannerComponent,
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatCardModule,
    MatInputModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [PriceCheckerService],
  bootstrap: [AppComponent]
})
export class AppModule { }

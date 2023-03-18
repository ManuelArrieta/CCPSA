import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PriceCheckerViewerComponent } from './components/price-checker-viewer/price-checker-viewer.component';

const routes: Routes = 
[  
  {path:'',component:PriceCheckerViewerComponent},
  {path:'**',component:PriceCheckerViewerComponent}  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

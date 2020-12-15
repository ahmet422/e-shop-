import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from "@angular/common/http";

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProductList } from "./shop/productList.component";
import { DataService } from "./shared/dataService";
import { APP_BASE_HREF } from '@angular/common';

@NgModule({
  declarations: [
        AppComponent,
        ProductList
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
    ],
    providers:
        [DataService, { provide: APP_BASE_HREF, useValue: '/' }],
  bootstrap: [AppComponent]
})
export class AppModule { }

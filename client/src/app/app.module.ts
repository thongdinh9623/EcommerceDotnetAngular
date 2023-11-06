import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HeaderContainerComponent } from './headers/header-container/header-container.component';
import { NavComponent } from './nav/nav.component';
import { MenuComponent } from './menu/menu.component';
import { HomeComponent } from './home/home.component';
import { BannerComponent } from './banner/banner.component';
import { HomeProductSectionComponent } from './home-product-section/home-product-section.component';
import { ProductCategoryMenuComponent } from './product-category-menu/product-category-menu.component';
import { HeaderLeftComponent } from './headers/header-left/header-left.component';
import { HeaderTopComponent } from './headers/header-top/header-top.component';
import { HeaderMiddleComponent } from './headers/header-middle/header-middle.component';
import { HeaderRightComponent } from './headers/header-right/header-right.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderContainerComponent,
    NavComponent,
    MenuComponent,
    HomeComponent,
    BannerComponent,
    HomeProductSectionComponent,
    ProductCategoryMenuComponent,
    HeaderLeftComponent,
    HeaderTopComponent,
    HeaderMiddleComponent,
    HeaderRightComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomePageSettingsComponent } from './homepage-settings.component';
import { Route, RouterModule } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatRadioModule } from '@angular/material/radio';
import { MatSelectModule } from '@angular/material/select';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { FuseAlertModule } from '@fuse/components/alert';
import { SharedModule } from 'app/shared/shared.module';
import { CoverCarouselsComponent } from './cover-carousels/cover-carousels.component';
import { CategoryItemsComponent } from './category-items/category-items.component';
import { FooterItemsComponent } from './footer-items/footer-items.component';
import { BrandItemsComponent } from './brand-items/brand-items.component';
import { TopCollectionItemsComponent } from './top-collection-items/top-collection-items.component';
import { ProductsItemsComponent } from './products-items/products-items.component';
import { SpecialProductsItemsComponent } from './special-products-items/special-products-items.component';
import { StrengthFieldsItemsComponent } from './strength-fields-items/strength-fields-items.component';

const homePageSettingsRoutes: Route[] = [
  {
    path: '',
    component: HomePageSettingsComponent
  },
];

@NgModule({
  declarations: [HomePageSettingsComponent, CoverCarouselsComponent, CategoryItemsComponent,
    FooterItemsComponent, BrandItemsComponent, TopCollectionItemsComponent,
    ProductsItemsComponent, SpecialProductsItemsComponent,
    StrengthFieldsItemsComponent],
  imports: [
    MatButtonModule,
    MatFormFieldModule,
    MatIconModule,
    MatInputModule,
    MatSidenavModule,
    MatSlideToggleModule,
    FuseAlertModule,
    SharedModule,
    CommonModule,
    RouterModule.forChild(homePageSettingsRoutes),
  ]
})
export class HomePageSettingsModule { }

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductpageSettingsComponent } from './productpage-settings.component';
import { Route, RouterModule } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { FuseAlertModule } from '@fuse/components/alert';
import { SharedModule } from 'app/shared/shared.module';
import { ProductFieldsComponent } from './product-fields/product-fields.component';

const productPageSettingsRoutes: Route[] = [
  {
    path: '',
    component: ProductpageSettingsComponent
  },
];

@NgModule({
  declarations: [
    ProductpageSettingsComponent, ProductFieldsComponent
  ],
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
    RouterModule.forChild(productPageSettingsRoutes),
  ]
})
export class ProductpageSettingsModule { }

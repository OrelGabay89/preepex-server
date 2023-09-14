import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { ProductsComponent } from './products.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Route, RouterModule } from '@angular/router';
import { MatInputModule } from '@angular/material/input';
import { SharedModule } from 'app/shared/shared.module';
import { InventoryBrandsResolver, InventoryCategoriesResolver, InventoryLabelsResolver, InventoryProductsResolver, InventoryTagsResolver, InventoryVendorsResolver } from './inventory.resolvers';
import { MatSortModule } from '@angular/material/sort';
import { MatRippleModule } from '@angular/material/core';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatMenuModule } from '@angular/material/menu';
import { MatSelectModule } from '@angular/material/select';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatTooltipModule } from '@angular/material/tooltip';
import { AngularEditorModule } from '@kolkov/angular-editor';
import { MatTabsModule } from '@angular/material/tabs';
import { MatExpansionModule } from '@angular/material/expansion';

const productsRoutes: Route[] = [
  {
    path: '',
    component: ProductsComponent,
    resolve: {
      brands: InventoryBrandsResolver,
      categories: InventoryCategoriesResolver,
      products: InventoryProductsResolver,
      tags: InventoryTagsResolver,
      labels: InventoryLabelsResolver,
      vendors: InventoryVendorsResolver
    }
  }
];


@NgModule({
  declarations: [
    ProductsComponent
  ],
  imports: [
    MatIconModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatCheckboxModule,
    MatMenuModule,
    MatPaginatorModule,
    MatProgressBarModule,
    MatRippleModule,
    MatSortModule,
    MatSelectModule,
    MatSlideToggleModule,
    MatTooltipModule,
    MatTabsModule,
    MatExpansionModule,
    AngularEditorModule,
    CommonModule,
    SharedModule,
    RouterModule.forChild(productsRoutes)
  ]
})
export class ProductsModule { }

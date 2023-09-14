import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OrdersComponent } from './orders.component';
import { Route, RouterModule } from '@angular/router';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatMenuModule } from '@angular/material/menu';
import { MatIconModule } from '@angular/material/icon';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { SharedModule } from 'app/shared/shared.module';
import { MatButtonModule } from '@angular/material/button';
import { MatSelectModule } from '@angular/material/select';
import { MatChipsModule } from '@angular/material/chips';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatRippleModule } from '@angular/material/core';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { OrderViewerComponent } from './order-viewer/order-viewer.component';
import { ShipmentListTabularComponent } from './order-viewer/shipment-list-tabular/shipment-list-tabular.component';
import { ProductListTabularComponent } from './order-viewer/product-list-tabular/product-list-tabular.component';
import { OrderNoteListTabularComponent } from './order-viewer/order-note-list-tabular/order-note-list-tabular.component';
import { AddressEditorComponent } from './address-editor/address-editor.component';
import { AddProductToOrderComponent } from './add-product-to-order/add-product-to-order.component';
import { ShipmentCreatorEditorComponent } from './shipment-creator-editor/shipment-creator-editor.component';

const orderRoutes: Route[] = [
  {
    path: '',
    component: OrdersComponent
  },
  {
    path: 'create',
    component: OrderViewerComponent
  },
  {
    path: 'edit/:id',
    component: OrderViewerComponent,
    data: {
      isEdit: true
    }
  },
  {
    path: 'editAddress/:id',
    component: AddressEditorComponent,
    data: {
      isEdit: true
    }
  },
  {
    path: 'editShipment/:id',
    component: ShipmentCreatorEditorComponent,
    data: {
      isEdit: true
    }
  },
  {
    path: 'addShipment/:id',
    component: ShipmentCreatorEditorComponent,

  },
  {
    path: 'addProduct/:id',
    component: AddProductToOrderComponent,
    data: {
      isEdit: true
    }
  }
];

@NgModule({
  declarations: [
    OrdersComponent,
    OrderViewerComponent,
    ShipmentListTabularComponent,
    ProductListTabularComponent,
    OrderNoteListTabularComponent,
    AddressEditorComponent,
    AddProductToOrderComponent,
    ShipmentCreatorEditorComponent
  ],
  imports: [
    MatIconModule,
    MatMenuModule,
    MatFormFieldModule,
    MatButtonModule,
    MatTableModule,
    MatCheckboxModule,
    MatPaginatorModule,
    MatProgressBarModule,
    MatSelectModule,
    MatInputModule,
    MatRippleModule,
    MatSortModule,
    MatSlideToggleModule,
    MatExpansionModule,
    MatChipsModule,
    CommonModule,
    SharedModule,
    RouterModule.forChild(orderRoutes),
  ]
})
export class OrdersModule { }

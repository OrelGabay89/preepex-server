import { Component, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DiscountComponent } from './discount.component';
import { Route, RouterModule } from '@angular/router';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { SharedModule } from 'app/shared/shared.module';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatOptionModule, MatRippleModule } from '@angular/material/core';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatSortModule } from '@angular/material/sort';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatTableModule } from '@angular/material/table';
import { DiscountCreatorEditorComponent } from './discount-creator-editor/discount-creator-editor.component';
import { MatMenuModule } from '@angular/material/menu';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatCheckboxModule } from '@angular/material/checkbox';

const discountRoute: Route[] = [
  {
    path: '',
    component: DiscountComponent
  },
  {
    path: 'create',
    component: DiscountCreatorEditorComponent
  },
  {
    path: 'edit/:id',
    component: DiscountCreatorEditorComponent,
    data: {
      isEdit: true
    }
  },
];

@NgModule({
  declarations: [
    DiscountComponent,
    DiscountCreatorEditorComponent
  ],
  imports: [
    MatIconModule,
    MatMenuModule,
    MatButtonModule,
    MatFormFieldModule,
    MatProgressBarModule,
    MatSlideToggleModule,
    MatOptionModule,
    MatExpansionModule,
    MatCheckboxModule,
    MatInputModule,
    MatSelectModule,
    MatRippleModule,
    MatSortModule,
    MatPaginatorModule,
    MatTableModule,
    SharedModule,
    CommonModule,
    RouterModule.forChild(discountRoute)
  ]
})
export class DiscountModule { }

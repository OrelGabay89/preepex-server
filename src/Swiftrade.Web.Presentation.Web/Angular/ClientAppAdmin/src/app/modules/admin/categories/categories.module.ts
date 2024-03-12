import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CategoriesComponent } from './categories.component';
import { RouterModule, Route } from '@angular/router';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { MatRippleModule } from '@angular/material/core';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatSortModule } from '@angular/material/sort';
import { MatIconModule } from '@angular/material/icon';
import { SharedModule } from 'app/shared/shared.module';
import { MatMenuModule } from '@angular/material/menu';
import { MatTableModule } from '@angular/material/table';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatSelectModule } from '@angular/material/select';
import { MatInputModule } from '@angular/material/input';
import { CategoryCreatorEditorComponent } from './category-creator-editor/category-creator-editor.component';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatExpansionModule } from '@angular/material/expansion';
import { AngularEditorModule } from '@kolkov/angular-editor';

const categoriesRoutes: Route[] = [
  {
    path: '',
    component: CategoriesComponent
  },
  {
    path: 'create',
    component: CategoryCreatorEditorComponent
  },
  {
    path: 'edit/:id',
    component: CategoryCreatorEditorComponent,
    data: {
      isEdit: true
    }
  }
];

@NgModule({
  declarations: [
    CategoriesComponent,
    CategoryCreatorEditorComponent
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
    AngularEditorModule,
    CommonModule,
    SharedModule,
    RouterModule.forChild(categoriesRoutes)
  ]
})
export class CategoriesModule { }

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserRolesComponent } from './user-roles.component';
import { Route, RouterModule } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';
import { MatRippleModule } from '@angular/material/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatSortModule } from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';
import { SharedModule } from 'app/shared/shared.module';
import { UserRolesCreatorEditorComponent } from './user-roles-creator-editor/user-roles-creator-editor.component';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatMenuModule } from '@angular/material/menu';
import { MatSelectModule } from '@angular/material/select';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { AngularEditorModule } from '@kolkov/angular-editor';

const userRolesRoutes: Route[] = [
  {
    path: '',
    component: UserRolesComponent
  },
  {
    path: 'create',
    component: UserRolesCreatorEditorComponent
  },
  {
    path: 'edit/:id',
    component: UserRolesCreatorEditorComponent,
    data: {
      isEdit: true
    }
  }
];

@NgModule({
  declarations: [
    UserRolesComponent,
    UserRolesCreatorEditorComponent
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
    RouterModule.forChild(userRolesRoutes)
  ]
})
export class UserRolesModule { }

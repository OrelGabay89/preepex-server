import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UsersComponent } from './users.component';
import { Route, RouterModule } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatRippleModule } from '@angular/material/core';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatMenuModule } from '@angular/material/menu';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatSelectModule } from '@angular/material/select';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatSortModule } from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';
import { AngularEditorModule } from '@kolkov/angular-editor';
import { SharedModule } from 'app/shared/shared.module';
import { UserCreatorEditorComponent } from './user-creator-editor/user-creator-editor.component';
import { MatRadioModule } from '@angular/material/radio';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatMomentDateModule } from '@angular/material-moment-adapter';

const userRoutes: Route[] = [
  {
    path: '',
    component: UsersComponent
  },
  {
    path: 'create',
    component: UserCreatorEditorComponent
  },
  {
    path: 'edit/:id',
    component: UserCreatorEditorComponent,
    data: {
      isEdit: true
    }
  }
];


@NgModule({
  declarations: [
    UsersComponent,
    UserCreatorEditorComponent
  ],
  imports: [
    MatIconModule,
    MatMenuModule,
    MatFormFieldModule,
    MatButtonModule,
    MatRadioModule,
    MatDatepickerModule,
    MatMomentDateModule,
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
    RouterModule.forChild(userRoutes)
  ]
})
export class UsersModule { }

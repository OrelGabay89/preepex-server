import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LabelsComponent } from './labels.component';
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
import { Route, RouterModule } from '@angular/router';
import { AngularEditorModule } from '@kolkov/angular-editor';
import { SharedModule } from 'app/shared/shared.module';
import { LabelsCreatorEditorComponent } from './labels-creator-editor/labels-creator-editor.component';

const labelsRoutes: Route[] = [
  {
    path: '',
    component: LabelsComponent
  },
  {
    path: 'create',
    component: LabelsCreatorEditorComponent
  },
  {
    path: 'edit/:id',
    component: LabelsCreatorEditorComponent,
    data: {
      isEdit: true
    }
  }
];

@NgModule({
  declarations: [
    LabelsComponent,
    LabelsCreatorEditorComponent
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
    RouterModule.forChild(labelsRoutes)
  ]
})
export class LabelsModule { }

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NewsletterComponent } from './newsletter.component';
import { Route, RouterModule } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';
import { MatOptionModule, MatRippleModule } from '@angular/material/core';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatMenuModule } from '@angular/material/menu';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatSelectModule } from '@angular/material/select';
import { MatSortModule } from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';
import { SharedModule } from 'app/shared/shared.module';

const newsletterRoute: Route[] = [
  {
    path: '',
    component: NewsletterComponent
  }
];

@NgModule({
  declarations: [
    NewsletterComponent
  ],
  imports: [
    MatIconModule,
    MatMenuModule,
    MatButtonModule,
    MatFormFieldModule,
    MatProgressBarModule,
    MatOptionModule,
    MatExpansionModule,
    MatInputModule,
    MatSelectModule,
    MatRippleModule,
    MatSortModule,
    MatPaginatorModule,
    MatTableModule,
    SharedModule,
    CommonModule,
    RouterModule.forChild(newsletterRoute)
  ]
})
export class NewsletterModule { }

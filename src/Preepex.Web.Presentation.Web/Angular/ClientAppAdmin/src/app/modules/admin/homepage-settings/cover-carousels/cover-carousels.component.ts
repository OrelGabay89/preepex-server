import { ChangeDetectionStrategy, Component, OnInit, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'app-cover-carousels',
  templateUrl: './cover-carousels.component.html',
  encapsulation: ViewEncapsulation.None,
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class CoverCarouselsComponent implements OnInit {

  public coverCarouselForm: Array<any> = [];
  public coverCarousels = [
    {
      imageURL: 'http://demo.preepex.com/assets/images/slider1.jpg',
      label: 'welcome to fashion',
      path: 'shop/category?category=fashion',
      title: 'men fashion'
    },
    {
      imageURL: 'http://demo.preepex.com/assets/images/slider2.jpg',
      label: 'welcome to fashion',
      path: 'shop/category?category=fashion',
      title: 'women fashion'
    }
  ];

  constructor(
  ) { }

  ngOnInit(): void {
    this.coverCarouselForm = [...this.coverCarousels];
  }

  addCarousel(): void {
    this.coverCarouselForm.push({
      imageURL: null,
      label: null,
      path: null,
      title: null
    });
  }

  removeCarousel(index: number): void {
    this.coverCarouselForm.splice(index, 1);
  }

  onFileDropped(data): void {
  }

  fileBrowseHandler(files): void {
  }

  trackByFn(index: number, item: any): any {
    return index;
  }

}


import { ChangeDetectionStrategy, Component, OnInit, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'app-strength-fields-items',
  templateUrl: './strength-fields-items.component.html',
  encapsulation: ViewEncapsulation.None,
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class StrengthFieldsItemsComponent implements OnInit {

  public itemsPerSlide: number = 3;
  public coverCarouselForm: Array<any> = [];
  public coverCarousels = [
    {
      imageURL: 'http://demo.preepex.com/assets/images/slider1.jpg',
      title: 'free shipping',
      description: 'Free Shipping World Wide'
    },
    {
      imageURL: 'http://demo.preepex.com/assets/images/slider2.jpg',
      title: '24x7 service',
      description: 'Online Service For New Customer'
    },
    {
      imageURL: 'http://demo.preepex.com/assets/images/slider3.jpg',
      title: 'festival offer',
      description: 'New Online Special Festival Offer'
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

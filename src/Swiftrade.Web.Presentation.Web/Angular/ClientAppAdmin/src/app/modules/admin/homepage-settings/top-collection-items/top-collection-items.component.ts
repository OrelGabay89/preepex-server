import { ChangeDetectionStrategy, Component, OnInit, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'app-top-collection-items',
  templateUrl: './top-collection-items.component.html',
  encapsulation: ViewEncapsulation.None,
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class TopCollectionItemsComponent implements OnInit {

  public collection = {
    itemsPerSlide: 4,
    title: 'top collection',
    label: 'special offer',
    description: 'Lorem Ipsum is simply dummy text of the printing and typesetting industry, Lorem Ipsum has been the industry\'s standard dummy text ever since the 1500s.',
  };

  constructor() { }

  ngOnInit(): void {
  }

}

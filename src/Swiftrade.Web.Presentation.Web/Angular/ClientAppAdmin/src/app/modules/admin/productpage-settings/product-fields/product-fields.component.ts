import { ChangeDetectionStrategy, Component, OnInit, ViewEncapsulation } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-product-fields',
  templateUrl: './product-fields.component.html',
  encapsulation: ViewEncapsulation.None,
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ProductFieldsComponent implements OnInit {

  public productFieldsForm: FormGroup;
  public productToggleFields = [
    {
      label: 'Show long description',
      id: 'longDesc'
    },
    {
      label: 'Show short description',
      id: 'shortDesc'
    },
    {
      label: 'Show tabs',
      id: 'tabs',
      subTabs: [
        {
          label: 'Show details tab',
          id: 'detail'
        },
        {
          label: 'Show more information tab',
          id: 'moreInformation'
        },
        {
          label: 'Show custom tab',
          id: 'custom'
        },
        {
          label: 'Show video tab',
          id: 'video'
        },
        {
          label: 'Show reviews tab',
          id: 'reviews'
        },
        {
          label: 'Show write reviews tab',
          id: 'writeReviews'
        }
      ]
    },
    {
      label: 'Show SKU',
      id: 'sku'
    },
    {
      label: 'Show GTIN',
      id: 'gtin'
    },
    {
      label: 'Show manufacturer part number',
      id: 'manufacturer'
    },
    {
      label: 'Show Vendor',
      id: 'vendor'
    },
    {
      label: 'Show Tags',
      id: 'tags'
    }
  ];

  constructor(
    private _formBuilder: FormBuilder
  ) { }

  ngOnInit(): void {
    this.productFieldsForm = this._formBuilder.group({
      longDesc: [true],
      shortDesc: [true],
      tabs: [true],
      detail: [false],
      moreInformation: [false],
      custom: [false],
      video: [false],
      reviews: [false],
      writeReviews: [false],
      sku: [false],
      gtin: [false],
      manufacturer: [true],
      vendor: [true],
      tags: [true],
      imageCounts: [4]
    });
  }

}

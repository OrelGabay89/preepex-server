import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-address-editor',
  templateUrl: './address-editor.component.html',
  encapsulation: ViewEncapsulation.None
})
export class AddressEditorComponent implements OnInit {

  isLoading: boolean;
  orderId: string;

  constructor(private _route: ActivatedRoute,
    private _router: Router,) {
    const snapshot = this._route.snapshot;
    this.orderId = snapshot.params.id;

  }
  ngOnInit(): void {
  }

  public saveAddress(): void {
    this.back();
  }

  public back(): void {
    this._router.navigate(['orders/edit', this.orderId]);
  }

}

import { ChangeDetectionStrategy, Component, OnInit, ViewEncapsulation } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';

@Component({
  selector: 'settings-social',
  templateUrl: './social.component.html',
  encapsulation: ViewEncapsulation.None,
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class SocialComponent implements OnInit {

  socialForm: FormGroup;
  intervalsArray = Array.from(Array(24).keys());

  constructor(private _formBuilder: FormBuilder) {
    this.socialForm = this._formBuilder.group({
      googleAuth: [false],
      googleClientId: [''],
      googleCaptcha: [false],
      googleCaptchaKey: [''],
      facebookAuth: [false],
      facebookClientId: [''],
      instagramConnect: [false],
      pullImages: [false],
      pullVideos: [false],
      pullInterval: [1],
    });
  }

  ngOnInit(): void {

  }

}

"use strict";(self.webpackChunkfuse=self.webpackChunkfuse||[]).push([[510],{3179:(Q,d,n)=>{n.r(d),n.d(d,{AuthUnlockSessionModule:()=>N});var c=n(4521),p=n(7423),l=n(7322),g=n(5245),f=n(8833),h=n(773),Z=n(6236),v=n(7775),A=n(4466),a=n(3075),x=n(8288),t=n(5e3),y=n(2060),U=n(7495),k=n(9808),S=n(2494);const w=["unlockSessionNgForm"];function T(e,i){if(1&e&&(t.TgZ(0,"fuse-alert",33),t._uU(1),t.qZA()),2&e){const o=t.oxw();t.Q6J("appearance","outline")("showIcon",!1)("type",o.alert.type)("@shake","error"===o.alert.type),t.xp6(1),t.hij(" ",o.alert.message," ")}}function C(e,i){1&e&&t._UZ(0,"mat-icon",34),2&e&&t.Q6J("svgIcon","heroicons_solid:eye")}function b(e,i){1&e&&t._UZ(0,"mat-icon",34),2&e&&t.Q6J("svgIcon","heroicons_solid:eye-off")}function F(e,i){1&e&&(t.TgZ(0,"span"),t._uU(1," Unlock your session "),t.qZA())}function I(e,i){1&e&&t._UZ(0,"mat-progress-spinner",35),2&e&&t.Q6J("diameter",24)("mode","indeterminate")}const J=function(){return["/sign-out"]},q=[{path:"",component:(()=>{class e{constructor(o,s,r,u,m){this._activatedRoute=o,this._authService=s,this._formBuilder=r,this._router=u,this._userService=m,this.alert={type:"success",message:""},this.showAlert=!1}ngOnInit(){this._userService.user$.subscribe(o=>{this.name=o.name,this._email=o.email}),this.unlockSessionForm=this._formBuilder.group({name:[{value:this.name,disabled:!0}],password:["",a.kI.required]})}unlock(){var o;this.unlockSessionForm.invalid||(this.unlockSessionForm.disable(),this.showAlert=!1,this._authService.unlockSession({email:null!==(o=this._email)&&void 0!==o?o:"",password:this.unlockSessionForm.get("password").value}).subscribe(()=>{const s=this._activatedRoute.snapshot.queryParamMap.get("redirectURL")||"/signed-in-redirect";this._router.navigateByUrl(s)},s=>{this.unlockSessionForm.enable(),this.unlockSessionNgForm.resetForm({name:{value:this.name,disabled:!0}}),this.alert={type:"error",message:"Invalid password"},this.showAlert=!0}))}}return e.\u0275fac=function(o){return new(o||e)(t.Y36(c.gz),t.Y36(y.e),t.Y36(a.qu),t.Y36(c.F0),t.Y36(U.K))},e.\u0275cmp=t.Xpm({type:e,selectors:[["auth-unlock-session"]],viewQuery:function(o,s){if(1&o&&t.Gf(w,5),2&o){let r;t.iGM(r=t.CRH())&&(s.unlockSessionNgForm=r.first)}},decls:52,vars:13,consts:[[1,"flex","flex-col","sm:flex-row","items-center","md:items-start","sm:justify-center","md:justify-start","flex-auto","min-w-0"],[1,"md:flex","md:items-center","md:justify-end","w-full","sm:w-auto","md:h-full","md:w-1/2","py-8","px-4","sm:p-12","md:p-16","sm:rounded-2xl","md:rounded-none","sm:shadow","md:shadow-none","sm:bg-card"],[1,"w-full","max-w-80","sm:w-80","mx-auto","sm:mx-0"],[1,"w-12"],["src","assets/images/logo/logo.svg"],[1,"mt-8","text-4xl","font-extrabold","tracking-tight","leading-tight"],[1,"mt-0.5","font-medium"],["class","mt-8 -mb-4",3,"appearance","showIcon","type",4,"ngIf"],[1,"mt-8",3,"formGroup"],["unlockSessionNgForm","ngForm"],[1,"w-full"],["id","name","matInput","",3,"formControlName"],["id","password","matInput","","type","password",3,"formControlName"],["passwordField",""],["mat-icon-button","","type","button","matSuffix","",3,"click"],["class","icon-size-5",3,"svgIcon",4,"ngIf"],["mat-flat-button","",1,"fuse-mat-button-large","w-full","mt-3",3,"color","disabled","click"],[4,"ngIf"],[3,"diameter","mode",4,"ngIf"],[1,"mt-8","text-md","font-medium","text-secondary"],[1,"ml-1","text-primary-500","hover:underline",3,"routerLink"],[1,"relative","hidden","md:flex","flex-auto","items-center","justify-center","w-1/2","h-full","p-16","lg:px-28","overflow-hidden","bg-gray-800","dark:border-l"],["viewBox","0 0 960 540","width","100%","height","100%","preserveAspectRatio","xMidYMax slice","xmlns","http://www.w3.org/2000/svg",1,"absolute","inset-0","pointer-events-none"],["fill","none","stroke","currentColor","stroke-width","100",1,"text-gray-700","opacity-25"],["r","234","cx","196","cy","23"],["r","234","cx","790","cy","491"],["viewBox","0 0 220 192","width","220","height","192","fill","none",1,"absolute","-top-16","-right-16","text-gray-700"],["id","837c3e70-6c3a-44e6-8854-cc48c737b659","x","0","y","0","width","20","height","20","patternUnits","userSpaceOnUse"],["x","0","y","0","width","4","height","4","fill","currentColor"],["width","220","height","192","fill","url(#837c3e70-6c3a-44e6-8854-cc48c737b659)"],[1,"z-10","relative","w-full","max-w-2xl"],[1,"text-7xl","font-bold","leading-none","text-gray-100"],[1,"mt-6","text-lg","tracking-tight","leading-6","text-gray-400"],[1,"mt-8","-mb-4",3,"appearance","showIcon","type"],[1,"icon-size-5",3,"svgIcon"],[3,"diameter","mode"]],template:function(o,s){if(1&o){const r=t.EpF();t.TgZ(0,"div",0),t.TgZ(1,"div",1),t.TgZ(2,"div",2),t.TgZ(3,"div",3),t._UZ(4,"img",4),t.qZA(),t.TgZ(5,"div",5),t._uU(6,"Unlock your session"),t.qZA(),t.TgZ(7,"div",6),t._uU(8,"Your session is locked due to inactivity"),t.qZA(),t.YNc(9,T,2,5,"fuse-alert",7),t.TgZ(10,"form",8,9),t.TgZ(12,"mat-form-field",10),t.TgZ(13,"mat-label"),t._uU(14,"Full name"),t.qZA(),t._UZ(15,"input",11),t.qZA(),t.TgZ(16,"mat-form-field",10),t.TgZ(17,"mat-label"),t._uU(18,"Password"),t.qZA(),t._UZ(19,"input",12,13),t.TgZ(21,"button",14),t.NdJ("click",function(){t.CHM(r);const m=t.MAs(20);return m.type="password"===m.type?"text":"password"}),t.YNc(22,C,1,1,"mat-icon",15),t.YNc(23,b,1,1,"mat-icon",15),t.qZA(),t.TgZ(24,"mat-error"),t._uU(25," Password is required "),t.qZA(),t.qZA(),t.TgZ(26,"button",16),t.NdJ("click",function(){return s.unlock()}),t.YNc(27,F,2,0,"span",17),t.YNc(28,I,1,2,"mat-progress-spinner",18),t.qZA(),t.TgZ(29,"div",19),t.TgZ(30,"span"),t._uU(31,"I'm not"),t.qZA(),t.TgZ(32,"a",20),t._uU(33),t.qZA(),t.qZA(),t.qZA(),t.qZA(),t.qZA(),t.TgZ(34,"div",21),t.O4$(),t.TgZ(35,"svg",22),t.TgZ(36,"g",23),t._UZ(37,"circle",24),t._UZ(38,"circle",25),t.qZA(),t.qZA(),t.TgZ(39,"svg",26),t.TgZ(40,"defs"),t.TgZ(41,"pattern",27),t._UZ(42,"rect",28),t.qZA(),t.qZA(),t._UZ(43,"rect",29),t.qZA(),t.kcU(),t.TgZ(44,"div",30),t.TgZ(45,"div",31),t.TgZ(46,"div"),t._uU(47,"Welcome to"),t.qZA(),t.TgZ(48,"div"),t._uU(49,"Preepex Admin"),t.qZA(),t.qZA(),t.TgZ(50,"div",32),t._uU(51," Manage and build your e-commerce shop. Join us and start building your shop today. "),t.qZA(),t.qZA(),t.qZA(),t.qZA()}if(2&o){const r=t.MAs(20);t.xp6(9),t.Q6J("ngIf",s.showAlert),t.xp6(1),t.Q6J("formGroup",s.unlockSessionForm),t.xp6(5),t.Q6J("formControlName","name"),t.xp6(4),t.Q6J("formControlName","password"),t.xp6(3),t.Q6J("ngIf","password"===r.type),t.xp6(1),t.Q6J("ngIf","text"===r.type),t.xp6(3),t.Q6J("color","primary")("disabled",s.unlockSessionForm.disabled),t.xp6(1),t.Q6J("ngIf",!s.unlockSessionForm.disabled),t.xp6(1),t.Q6J("ngIf",s.unlockSessionForm.disabled),t.xp6(4),t.Q6J("routerLink",t.DdM(12,J)),t.xp6(1),t.Oqu(s.name)}},directives:[k.O5,a._Y,a.JL,a.sg,l.KE,l.hX,f.Nt,a.Fj,a.JJ,a.u,p.lW,l.R9,l.TO,c.yS,S.W,g.Hw,h.Ou],encapsulation:2,data:{animation:x.L}}),e})()}];let N=(()=>{class e{}return e.\u0275fac=function(o){return new(o||e)},e.\u0275mod=t.oAB({type:e}),e.\u0275inj=t.cJS({imports:[[c.Bz.forChild(q),p.ot,l.lN,g.Ps,f.c,h.Cq,Z.J,v.fC,A.m]]}),e})()}}]);
"use strict";(self.webpackChunkfuse=self.webpackChunkfuse||[]).push([[448],{6448:(Ve,D,s)=>{s.r(D),s.d(D,{UsersModule:()=>Oe});var C=s(9808),e=s(5e3),h=s(6087),_=s(4847),l=s(4999),f=s(4521),q=s(1683),x=s(7423),A=s(5245),Z=s(2181),c=s(1125),m=s(7322),U=s(8833),g=s(3075),v=s(4107),d=s(508),b=s(5899),M=s(7446);function Q(n,r){1&n&&(e.TgZ(0,"div",46),e._UZ(1,"mat-progress-bar",47),e.qZA()),2&n&&(e.xp6(1),e.Q6J("mode","indeterminate"))}function S(n,r){if(1&n){const t=e.EpF();e.TgZ(0,"th",48),e.TgZ(1,"mat-checkbox",49),e.NdJ("change",function(a){return e.CHM(t),e.oxw().masterToggle(a)}),e.qZA(),e.qZA()}if(2&n){const t=e.oxw();e.xp6(1),e.Q6J("checked",t.isAllSelected)}}function w(n,r){if(1&n){const t=e.EpF();e.TgZ(0,"td",50),e.TgZ(1,"mat-checkbox",49),e.NdJ("change",function(a){const u=e.CHM(t).$implicit;return e.oxw().toggleSelect(a,u)}),e.qZA(),e.qZA()}if(2&n){const t=r.$implicit;e.xp6(1),e.Q6J("checked",t.isSelected)}}function k(n,r){1&n&&(e.TgZ(0,"th",51),e._uU(1," Email "),e.qZA())}function Y(n,r){if(1&n&&(e.TgZ(0,"td",50),e._uU(1),e.qZA()),2&n){const t=r.$implicit;e.xp6(1),e.hij(" ",t.email," ")}}function I(n,r){1&n&&(e.TgZ(0,"th",51),e._uU(1," Name "),e.qZA())}function O(n,r){if(1&n&&(e.TgZ(0,"td",50),e._uU(1),e.qZA()),2&n){const t=r.$implicit;e.xp6(1),e.hij(" ",t.name," ")}}function V(n,r){1&n&&(e.TgZ(0,"th",51),e._uU(1," User roles "),e.qZA())}function G(n,r){if(1&n&&(e.TgZ(0,"td",50),e._uU(1),e.qZA()),2&n){const t=r.$implicit;e.xp6(1),e.hij(" ",t.role," ")}}function F(n,r){1&n&&(e.TgZ(0,"th",51),e._uU(1," Company name "),e.qZA())}function P(n,r){if(1&n&&(e.TgZ(0,"td",50),e._uU(1),e.qZA()),2&n){const t=r.$implicit;e.xp6(1),e.hij(" ",t.company," ")}}function B(n,r){1&n&&(e.TgZ(0,"th",51),e._uU(1," Active "),e.qZA())}function H(n,r){1&n&&(e.TgZ(0,"td",50),e._UZ(1,"mat-icon",52),e.qZA()),2&n&&(e.xp6(1),e.Q6J("svgIcon","heroicons_solid:check"))}function R(n,r){1&n&&(e.TgZ(0,"th",48),e._uU(1," View "),e.qZA())}function L(n,r){if(1&n){const t=e.EpF();e.TgZ(0,"td",50),e.TgZ(1,"mat-icon",53),e.NdJ("click",function(){const i=e.CHM(t).$implicit;return e.oxw().editUser(i.id)}),e.qZA(),e.qZA()}2&n&&(e.xp6(1),e.Q6J("svgIcon","heroicons_solid:eye"))}function j(n,r){1&n&&(e.TgZ(0,"th",48),e._uU(1," Edit "),e.qZA())}function z(n,r){if(1&n){const t=e.EpF();e.TgZ(0,"td",50),e.TgZ(1,"mat-icon",53),e.NdJ("click",function(){const i=e.CHM(t).$implicit;return e.oxw().editUser(i.id)}),e.qZA(),e.qZA()}2&n&&(e.xp6(1),e.Q6J("svgIcon","heroicons_solid:pencil-alt"))}function W(n,r){1&n&&(e.TgZ(0,"th",48),e._uU(1," Delete "),e.qZA())}function $(n,r){if(1&n){const t=e.EpF();e.TgZ(0,"td",50),e.TgZ(1,"mat-icon",54),e.NdJ("click",function(){const i=e.CHM(t).$implicit;return e.oxw().deleteUser(i.id)}),e.qZA(),e.qZA()}if(2&n){const t=e.oxw();e.xp6(1),e.Q6J("color",t.danger)("svgIcon","heroicons_solid:trash")}}function X(n,r){1&n&&e._UZ(0,"tr",55)}function K(n,r){1&n&&e._UZ(0,"tr",56)}const ee=function(){return[5,10,20]};let te=(()=>{class n{constructor(t,o,a){this.router=t,this._route=o,this._fuseConfirmationService=a,this.paginator=new e.n_E,this.users=[{name:"Steve Gates",email:"steve_gates@nopCommerce.com",role:"Registered",id:"b899ec30-b85a-40ab-bb1f-18a596d5c6de",company:"Preepex",ipAddress:"45261",active:!0,edit:"",isSelected:!1},{name:"\tArthur Holmes",email:"arthur_holmes@nopCommerce.com",role:"Registered",id:"b899ec30-b85a-50ab-bb1f-18a596d5c6de",company:"Preepex",ipAddress:"45262",active:!0,edit:"Registered",isSelected:!1},{name:"James Pan",email:"james_pan@nopCommerce.com",role:"Forum Moderators",id:"b899ec30-b85a-60ab-bb1f-18a596d5c6de",company:"Preepex",ipAddress:"45266",active:!0,edit:"",isSelected:!1},{name:"Brenda Lindgren",email:"brenda_lindgren@nopCommerce.com",role:"Administrators, Registered",id:"b899ec30-b85a-70ab-bb1f-18a596d5c6de",company:"Preepex",ipAddress:"45266",active:!0,edit:"",isSelected:!1},{name:"Victoria Terces",email:"victoria_victoria@nopCommerce.com",role:"Administrators",id:"b899ec30-b85a-80ab-bb1f-18a596d5c6de",company:"Preepex",ipAddress:"45266",active:!0,edit:"",isSelected:!1},{name:"John Smith",email:"admin@preepex.com",role:"Registered",id:"b899ec30-b85a-90ab-bb2f-18a596d5c6de",company:"Preepex",ipAddress:"45266",active:!0,edit:"",isSelected:!1},{name:"Guest",email:"guest@preepex.com",role:"Guests",id:"b899ec30-b85a-90ab-bb3f-18a596d5c6de",company:"Preepex",ipAddress:"45266",active:!0,edit:"",isSelected:!1},{name:"Guest",email:"guest@preepex.com",role:"Guests",id:"b899ec30-b85a-90ab-bb4f-18a596d5c6de",company:"Preepex",ipAddress:"45266",active:!0,edit:"",isSelected:!1},{name:"Guest",email:"guest@preepex.com",role:"Guests",id:"b899ec30-b85a-90ab-bb5f-18a596d5c6de",company:"Preepex",ipAddress:"45266",active:!0,edit:"",isSelected:!1},{name:"Guest",email:"guest@preepex.com",role:"Guests",id:"b899ec30-b85a-90ab-bb6f-18a596d5c6de",company:"Preepex",ipAddress:"45266",active:!0,edit:"",isSelected:!1},{name:"Guest",email:"guest@preepex.com",role:"Guests",id:"b899ec30-b85a-90ab-bb7f-18a596d5c6de",company:"Preepex",ipAddress:"45266",active:!0,edit:"",isSelected:!1},{name:"Guest",email:"guest@preepex.com",role:"Guests",id:"b899ec30-b85a-90ab-bb8f-18a596d5c6de",company:"Preepex",ipAddress:"45266",active:!0,edit:"",isSelected:!1},{name:"Guest",email:"guest@preepex.com",role:"Guests",id:"b899ec30-b85a-90ab-bb9f-18a596d5c6de",company:"Preepex",ipAddress:"45266",active:!0,edit:"",isSelected:!1},{name:"Guest",email:"guest@preepex.com",role:"Guests",id:"b899ec30-b85a-90ab-bb1f-18a596d6c6de",company:"Preepex",ipAddress:"45266",active:!0,edit:"",isSelected:!1},{name:"Guest",email:"guest@preepex.com",role:"Guests",id:"b899ec30-b85a-90ab-bb1f-18a596d7c6de",company:"Preepex",ipAddress:"45266",active:!0,edit:"",isSelected:!1}],this.filterValue={email:"",company:"",name:"",ipAddress:"",role:[]},this.isLoading=!1,this.filteredUsers=this.users,this.usersDisplayedColumns=["select","email","name","role","company","active","view","edit","delete"],this.usersDataSource=new l.by(this.filteredUsers)}ngOnInit(){}ngAfterViewInit(){this.usersDataSource.paginator=this.paginator.toArray()[0],this.usersDataSource.sort=this.sort}masterToggle(t){this.users.forEach(t.checked?o=>o.isSelected=!0:o=>o.isSelected=!1)}toggleSelect(t,o){this.users.find(i=>i.id===o.id).isSelected=t.checked,this.isAllSelected=this.users.every(i=>i.isSelected)}filterData(){this.usersDataSource.data=this.users,this.filterValue.email&&(this.usersDataSource.data=this.usersDataSource.data.filter(t=>t.email.toLowerCase().includes(this.filterValue.email.toLowerCase()))),this.filterValue.company&&(this.usersDataSource.data=this.usersDataSource.data.filter(t=>t.company.toLowerCase().includes(this.filterValue.company.toLowerCase()))),this.filterValue.name&&(this.usersDataSource.data=this.usersDataSource.data.filter(t=>t.name.toLowerCase().includes(this.filterValue.name.toLowerCase()))),this.filterValue.ipAddress&&(this.usersDataSource.data=this.usersDataSource.data.filter(t=>t.ipAddress.toLowerCase().includes(this.filterValue.ipAddress.toLowerCase()))),this.filterValue.role&&this.filterValue.role.length&&(this.usersDataSource.data=this.usersDataSource.data.filter(t=>this.filterValue.role.some(o=>o.toLowerCase().includes(t.role.toLowerCase()))))}clearSearchFilter(){this.filterValue={email:"",company:"",name:"",ipAddress:"",role:[]},this.usersDataSource.data=this.users}createUser(){this.router.navigate(["create"],{relativeTo:this._route})}exportUser(){}importUser(){}deleteUser(t){this.users.filter(a=>a.id===t)&&this._fuseConfirmationService.open({title:"Delete user",message:"Are you sure you want to remove this user? This action cannot be undone!",actions:{confirm:{label:"Delete"}}}).afterClosed().subscribe(i=>{"confirmed"===i&&(this.usersDataSource.data=this.usersDataSource.data.filter(u=>u.id!==t))})}editUser(t){this.router.navigate(["edit",t],{relativeTo:this._route})}}return n.\u0275fac=function(t){return new(t||n)(e.Y36(f.F0),e.Y36(f.gz),e.Y36(q.R))},n.\u0275cmp=e.Xpm({type:n,selectors:[["app-users"]],viewQuery:function(t,o){if(1&t&&(e.Gf(_.YE,5),e.Gf(h.NW,5)),2&t){let a;e.iGM(a=e.CRH())&&(o.sort=a.first),e.iGM(a=e.CRH())&&(o.paginator=a)}},decls:106,vars:31,consts:[[1,"flex","flex-col","flex-auto","min-w-0","overflow-auto","bg-card","dark:bg-transparent"],[1,"relative","flex","flex-col","md:flex-row","flex-0","md:items-center","md:justify-between","py-8","px-6","md:px-8"],["class","absolute inset-x-0 bottom-0",4,"ngIf"],[1,"text-4xl","font-extrabold","tracking-tight"],[1,"flex","flex-wrap","justify-center","shrink-0","items-start","sm:items-center","mt-6","lg:mt-0","lg:ml-4"],["mat-flat-button","",1,"ml-2","sm:ml-4","mb-3","lg:mb-0","min-w-50","sm:min-w-0",3,"color","click"],[3,"svgIcon"],[1,"ml-2","mr-1"],["mat-flat-button","",1,"ml-2","sm:ml-4","mb-3","lg:mb-0","min-w-50","sm:min-w-0","bg-amber-500","mat-flat-button","mat-accent"],[1,"ml-2","mr-2"],["mat-icon-button","",3,"matMenuTriggerFor"],[1,"icon-size-5",3,"svgIcon"],["exportMenu","matMenu"],["mat-menu-item","",3,"click"],[1,"flex","flex-col","flex-auto","bg-card","shadow","rounded-2xl","px-2","md:px-8","pb-2","md:pb-8"],[1,"border"],[3,"collapsedHeight","expandedHeight"],[1,"text-xl","flex","items-center"],["matPrefix","",1,"icon-size-5","mr-2",3,"svgIcon"],[1,"pt-3"],[1,"flex","flex-col","sm:flex-row"],[1,"w-full","mx-2"],["matInput","",3,"ngModel","ngModelChange"],["query",""],["multiple","",3,"ngModel","ngModelChange"],[3,"value"],[1,"flex","items-center","justify-end","m-2"],["mat-flat-button","","type","button",1,"ml-4",3,"color","click"],[1,"overflow-x-auto","mt-8","sm:mt-10"],["mat-table","","matSort","",1,"w-full",3,"dataSource"],["matColumnDef","select"],["mat-header-cell","",4,"matHeaderCellDef"],["mat-cell","",4,"matCellDef"],["matColumnDef","email"],["mat-header-cell","","mat-sort-header","",4,"matHeaderCellDef"],["matColumnDef","name"],["matColumnDef","role"],["matColumnDef","company"],["matColumnDef","active"],["matColumnDef","view"],["matColumnDef","edit"],["matColumnDef","delete"],["class","h-14","mat-header-row","",4,"matHeaderRowDef"],["class","h-15","mat-row","",4,"matRowDef","matRowDefColumns"],["showFirstLastButtons","",3,"pageSizeOptions"],[1,"p-8","sm:p-16","border-t","text-4xl","font-semibold","tracking-tight","text-center"],[1,"absolute","inset-x-0","bottom-0"],[3,"mode"],["mat-header-cell",""],[3,"checked","change"],["mat-cell",""],["mat-header-cell","","mat-sort-header",""],[1,"icon-size-5","mr-1","cursor-pointer","mat-primary",3,"svgIcon"],[1,"icon-size-5","mr-1","cursor-pointer",3,"svgIcon","click"],[1,"icon-size-5","mr-1","cursor-pointer",3,"color","svgIcon","click"],["mat-header-row","",1,"h-14"],["mat-row","",1,"h-15"]],template:function(t,o){if(1&t&&(e.TgZ(0,"div",0),e.TgZ(1,"div",1),e.YNc(2,Q,2,1,"div",2),e.TgZ(3,"div",3),e._uU(4,"Users"),e.qZA(),e.TgZ(5,"div",4),e.TgZ(6,"button",5),e.NdJ("click",function(){return o.createUser()}),e._UZ(7,"mat-icon",6),e.TgZ(8,"span",7),e._uU(9,"Add New"),e.qZA(),e.qZA(),e.TgZ(10,"button",8),e._UZ(11,"mat-icon",6),e.TgZ(12,"span",9),e._uU(13,"Export"),e.qZA(),e.TgZ(14,"button",10),e._UZ(15,"mat-icon",11),e.qZA(),e.TgZ(16,"mat-menu",null,12),e.TgZ(18,"button",13),e.NdJ("click",function(){return o.exportUser()}),e._UZ(19,"mat-icon",6),e._uU(20,"Export to XML "),e.qZA(),e.TgZ(21,"button",13),e.NdJ("click",function(){return o.exportUser()}),e._UZ(22,"mat-icon",6),e._uU(23,"Export to Excel "),e.qZA(),e.qZA(),e.qZA(),e.qZA(),e.qZA(),e.TgZ(24,"div",14),e.TgZ(25,"mat-accordion"),e.TgZ(26,"mat-expansion-panel",15),e.TgZ(27,"mat-expansion-panel-header",16),e.TgZ(28,"mat-panel-title",17),e._UZ(29,"mat-icon",18),e._uU(30,"Search "),e.qZA(),e.qZA(),e.TgZ(31,"div",19),e.TgZ(32,"div",20),e.TgZ(33,"mat-form-field",21),e.TgZ(34,"mat-label"),e._uU(35,"Email"),e.qZA(),e.TgZ(36,"input",22,23),e.NdJ("ngModelChange",function(i){return o.filterValue.email=i})("ngModelChange",function(){return o.filterData()}),e.qZA(),e.qZA(),e.TgZ(38,"mat-form-field",21),e.TgZ(39,"mat-label"),e._uU(40,"Company"),e.qZA(),e.TgZ(41,"input",22,23),e.NdJ("ngModelChange",function(i){return o.filterValue.company=i})("ngModelChange",function(){return o.filterData()}),e.qZA(),e.qZA(),e.qZA(),e.TgZ(43,"div",20),e.TgZ(44,"mat-form-field",21),e.TgZ(45,"mat-label"),e._uU(46,"Name"),e.qZA(),e.TgZ(47,"input",22),e.NdJ("ngModelChange",function(i){return o.filterValue.name=i})("ngModelChange",function(){return o.filterData()}),e.qZA(),e.qZA(),e.TgZ(48,"mat-form-field",21),e.TgZ(49,"mat-label"),e._uU(50,"IP address"),e.qZA(),e.TgZ(51,"input",22),e.NdJ("ngModelChange",function(i){return o.filterValue.ipAddress=i})("ngModelChange",function(){return o.filterData()}),e.qZA(),e.qZA(),e.qZA(),e.TgZ(52,"div",20),e.TgZ(53,"mat-form-field",21),e.TgZ(54,"mat-label"),e._uU(55,"User roles"),e.qZA(),e.TgZ(56,"mat-select",24),e.NdJ("ngModelChange",function(i){return o.filterValue.role=i})("ngModelChange",function(){return o.filterData()}),e.TgZ(57,"mat-option",25),e._uU(58,"Registered"),e.qZA(),e.TgZ(59,"mat-option",25),e._uU(60,"Forum Moderators"),e.qZA(),e.TgZ(61,"mat-option",25),e._uU(62,"Administrators"),e.qZA(),e.TgZ(63,"mat-option",25),e._uU(64,"Guests"),e.qZA(),e.TgZ(65,"mat-option",25),e._uU(66,"Vendors"),e.qZA(),e.qZA(),e.qZA(),e.qZA(),e.TgZ(67,"div",26),e.TgZ(68,"button",27),e.NdJ("click",function(){return o.clearSearchFilter()}),e._uU(69,"Clear "),e.qZA(),e.qZA(),e.qZA(),e.qZA(),e.qZA(),e.TgZ(70,"div",28),e.TgZ(71,"div"),e.TgZ(72,"table",29),e.ynx(73,30),e.YNc(74,S,2,1,"th",31),e.YNc(75,w,2,1,"td",32),e.BQk(),e.ynx(76,33),e.YNc(77,k,2,0,"th",34),e.YNc(78,Y,2,1,"td",32),e.BQk(),e.ynx(79,35),e.YNc(80,I,2,0,"th",34),e.YNc(81,O,2,1,"td",32),e.BQk(),e.ynx(82,36),e.YNc(83,V,2,0,"th",34),e.YNc(84,G,2,1,"td",32),e.BQk(),e.ynx(85,37),e.YNc(86,F,2,0,"th",34),e.YNc(87,P,2,1,"td",32),e.BQk(),e.ynx(88,38),e.YNc(89,B,2,0,"th",34),e.YNc(90,H,2,1,"td",32),e.BQk(),e.ynx(91,39),e.YNc(92,R,2,0,"th",31),e.YNc(93,L,2,1,"td",32),e.BQk(),e.ynx(94,40),e.YNc(95,j,2,0,"th",31),e.YNc(96,z,2,1,"td",32),e.BQk(),e.ynx(97,41),e.YNc(98,W,2,0,"th",31),e.YNc(99,$,2,2,"td",32),e.BQk(),e.YNc(100,X,1,0,"tr",42),e.YNc(101,K,1,0,"tr",43),e.qZA(),e._UZ(102,"mat-paginator",44),e.qZA(),e.TgZ(103,"div"),e.TgZ(104,"div",45),e._uU(105,"There are no users! "),e.qZA(),e.qZA(),e.qZA(),e.qZA(),e.qZA()),2&t){const a=e.MAs(17);e.xp6(2),e.Q6J("ngIf",o.isLoading),e.xp6(4),e.Q6J("color","primary"),e.xp6(1),e.Q6J("svgIcon","heroicons_outline:plus"),e.xp6(4),e.Q6J("svgIcon","heroicons_outline:cloud-download"),e.xp6(3),e.Q6J("matMenuTriggerFor",a),e.xp6(1),e.Q6J("svgIcon","heroicons_solid:dots-vertical"),e.xp6(4),e.Q6J("svgIcon","heroicons_outline:code"),e.xp6(3),e.Q6J("svgIcon","heroicons_outline:clipboard-list"),e.xp6(5),e.Q6J("collapsedHeight","50px")("expandedHeight","50px"),e.xp6(2),e.Q6J("svgIcon","heroicons_solid:search"),e.xp6(7),e.Q6J("ngModel",o.filterValue.email),e.xp6(5),e.Q6J("ngModel",o.filterValue.company),e.xp6(6),e.Q6J("ngModel",o.filterValue.name),e.xp6(4),e.Q6J("ngModel",o.filterValue.ipAddress),e.xp6(5),e.Q6J("ngModel",o.filterValue.role),e.xp6(1),e.Q6J("value","registered"),e.xp6(2),e.Q6J("value","forumModerators"),e.xp6(2),e.Q6J("value","administrators"),e.xp6(2),e.Q6J("value","guests"),e.xp6(2),e.Q6J("value","vendors"),e.xp6(3),e.Q6J("color","primary"),e.xp6(3),e.ekj("hidden",!o.usersDataSource.data.length),e.xp6(1),e.Q6J("dataSource",o.usersDataSource),e.xp6(28),e.Q6J("matHeaderRowDef",o.usersDisplayedColumns),e.xp6(1),e.Q6J("matRowDefColumns",o.usersDisplayedColumns),e.xp6(1),e.Q6J("pageSizeOptions",e.DdM(30,ee)),e.xp6(1),e.ekj("hidden",o.usersDataSource.data.length)}},directives:[C.O5,x.lW,A.Hw,Z.p6,Z.VK,Z.OP,c.pp,c.ib,c.yz,c.yK,m.qo,m.KE,m.hX,U.Nt,g.Fj,g.JJ,g.On,v.gD,d.ey,l.BZ,_.YE,l.w1,l.fO,l.Dz,l.as,l.nj,h.NW,b.pW,l.ge,M.oG,l.ev,_.nU,l.XQ,l.Gk],encapsulation:2}),n})();var ne=s(2368),oe=s(9345),re=s(4466),y=s(9814),T=s(6856);const ae=["ordersPaginator"],ie=["ordersTableSort"];function se(n,r){1&n&&(e.TgZ(0,"div",36),e._UZ(1,"mat-progress-bar",37),e.qZA()),2&n&&(e.xp6(1),e.Q6J("mode","indeterminate"))}function le(n,r){if(1&n&&(e.ynx(0),e.TgZ(1,"div",38),e._uU(2," Edit user details "),e.TgZ(3,"small"),e.TgZ(4,"small"),e._uU(5),e.qZA(),e.qZA(),e.qZA(),e.BQk()),2&n){const t=e.oxw();e.xp6(5),e.Oqu(t.user.info.name)}}function ce(n,r){1&n&&e._uU(0,"Add a new user")}function me(n,r){if(1&n){const t=e.EpF();e.ynx(0),e.TgZ(1,"button",39),e.NdJ("click",function(){return e.CHM(t),e.oxw().sendEmail()}),e._UZ(2,"mat-icon",40),e.TgZ(3,"span",10),e._uU(4,"Send email"),e.qZA(),e.qZA(),e.BQk()}}function de(n,r){if(1&n){const t=e.EpF();e.ynx(0),e.TgZ(1,"button",8),e.NdJ("click",function(){return e.CHM(t),e.oxw().deleteBrand()}),e._UZ(2,"mat-icon",41),e.TgZ(3,"span",10),e._uU(4,"Delete"),e.qZA(),e.qZA(),e.BQk()}2&n&&(e.xp6(1),e.Q6J("color","warn"))}function ue(n,r){1&n&&(e.TgZ(0,"th",59),e._uU(1," Order # "),e.qZA())}function pe(n,r){1&n&&e._UZ(0,"td",60)}function _e(n,r){1&n&&(e.TgZ(0,"th",61),e._uU(1," Order total "),e.qZA())}function ge(n,r){if(1&n&&(e.TgZ(0,"td",60),e._uU(1),e.qZA()),2&n){const t=r.$implicit;e.xp6(1),e.hij(" ",t.orderTotal," ")}}function fe(n,r){1&n&&(e.TgZ(0,"th",59),e._uU(1," Order status "),e.qZA())}function he(n,r){if(1&n&&(e.TgZ(0,"td",60),e._uU(1),e.qZA()),2&n){const t=r.$implicit;e.xp6(1),e.hij(" ",t.orderStatus," ")}}function Ze(n,r){1&n&&(e.TgZ(0,"th",59),e._uU(1," Payment status "),e.qZA())}function Te(n,r){if(1&n&&(e.TgZ(0,"td",60),e._uU(1),e.qZA()),2&n){const t=r.$implicit;e.xp6(1),e.hij(" ",t.paymentStatus," ")}}function Ce(n,r){1&n&&(e.TgZ(0,"th",59),e._uU(1," Shipping status "),e.qZA())}function xe(n,r){if(1&n&&(e.TgZ(0,"td",60),e._uU(1),e.qZA()),2&n){const t=r.$implicit;e.xp6(1),e.hij(" ",t.shippingStatus," ")}}function Ae(n,r){1&n&&(e.TgZ(0,"th",59),e._uU(1," Created on "),e.qZA())}function Ue(n,r){if(1&n&&(e.TgZ(0,"td",60),e._uU(1),e.qZA()),2&n){const t=r.$implicit;e.xp6(1),e.hij(" ",t.createdOn," ")}}function ve(n,r){1&n&&(e.TgZ(0,"th",61),e._uU(1," View "),e.qZA())}function be(n,r){1&n&&(e.TgZ(0,"td",60),e._UZ(1,"mat-icon",62),e.qZA()),2&n&&(e.xp6(1),e.Q6J("svgIcon","heroicons_solid:eye"))}function Me(n,r){1&n&&e._UZ(0,"tr",63)}function ye(n,r){1&n&&e._UZ(0,"tr",64)}const De=function(){return[5,10,20]};function qe(n,r){if(1&n&&(e.ynx(0),e.TgZ(1,"table",43,44),e.ynx(3,45),e.YNc(4,ue,2,0,"th",46),e.YNc(5,pe,1,0,"td",47),e.BQk(),e.ynx(6,48),e.YNc(7,_e,2,0,"th",49),e.YNc(8,ge,2,1,"td",47),e.BQk(),e.ynx(9,50),e.YNc(10,fe,2,0,"th",46),e.YNc(11,he,2,1,"td",47),e.BQk(),e.ynx(12,51),e.YNc(13,Ze,2,0,"th",46),e.YNc(14,Te,2,1,"td",47),e.BQk(),e.ynx(15,52),e.YNc(16,Ce,2,0,"th",46),e.YNc(17,xe,2,1,"td",47),e.BQk(),e.ynx(18,53),e.YNc(19,Ae,2,0,"th",46),e.YNc(20,Ue,2,1,"td",47),e.BQk(),e.ynx(21,54),e.YNc(22,ve,2,0,"th",49),e.YNc(23,be,2,1,"td",47),e.BQk(),e.YNc(24,Me,1,0,"tr",55),e.YNc(25,ye,1,0,"tr",56),e.qZA(),e._UZ(26,"mat-paginator",57,58),e.BQk()),2&n){const t=e.oxw(2);e.xp6(1),e.Q6J("dataSource",t.ordersDataSource),e.xp6(23),e.Q6J("matHeaderRowDef",t.ordersDisplayedColumns),e.xp6(1),e.Q6J("matRowDefColumns",t.ordersDisplayedColumns),e.xp6(1),e.Q6J("pageSizeOptions",e.DdM(4,De))}}function Je(n,r){if(1&n&&(e.ynx(0),e.TgZ(1,"mat-expansion-panel"),e.TgZ(2,"mat-expansion-panel-header",16),e.TgZ(3,"mat-panel-title",17),e._UZ(4,"mat-icon",42),e._uU(5," \xa0 Orders "),e.qZA(),e.qZA(),e.TgZ(6,"div",19),e.YNc(7,qe,28,5,"ng-container",11),e.qZA(),e.qZA(),e.BQk()),2&n){const t=e.oxw();e.xp6(2),e.Q6J("collapsedHeight","60px")("expandedHeight","60px"),e.xp6(5),e.Q6J("ngIf",t.userId)}}let J=(()=>{class n{constructor(t,o,a){this._route=t,this._router=o,this._fuseConfirmationService=a,this.user={info:{email:"",password:"",first:"",last:"",gender:"",company:"",tax:!1,newsletter:"",roles:"",vendor:"",active:!0,adminComment:""}},this.ordersDataSource=new l.by,this.ordersDisplayedColumns=["index","orderTotal","orderStatus","paymentStatus","shippingStatus","createdOn","view"];const i=this._route.snapshot;this.isEdit=null==i?void 0:i.data.isEdit,this.isEdit&&(this.userId=i.params.id)}ngOnInit(){}ngAfterViewInit(){this.ordersDataSource.paginator=this.ordersPaginator,this.ordersDataSource.sort=this.ordersTableSort}saveAndRedirect(){this.back()}save(){this.userId="b899ec30-b85a-40ab-bb1f-18a596d5c6de",this.isEdit=!0}back(){this._router.navigate(this.isEdit?["../.."]:[".."],{relativeTo:this._route})}deleteBrand(){this._fuseConfirmationService.open({title:"Delete user",message:"Are you sure you want to remove this user? This action cannot be undone!",actions:{confirm:{label:"Delete"}}}).afterClosed().subscribe(o=>{"confirmed"===o&&this.back()})}sendEmail(){}clearSearchFilter(){}}return n.\u0275fac=function(t){return new(t||n)(e.Y36(f.gz),e.Y36(f.F0),e.Y36(q.R))},n.\u0275cmp=e.Xpm({type:n,selectors:[["app-user-creator-editor"]],viewQuery:function(t,o){if(1&t&&(e.Gf(ae,5),e.Gf(ie,5)),2&t){let a;e.iGM(a=e.CRH())&&(o.ordersPaginator=a.first),e.iGM(a=e.CRH())&&(o.ordersTableSort=a.first)}},decls:102,vars:35,consts:[[1,"flex","flex-col","flex-auto","min-w-0","overflow-auto","bg-card","dark:bg-transparentt"],[1,"relative","flex","flex-col","lg:flex-row","flex-0","lg:items-center","lg:justify-between","py-8","px-6","md:px-8","border-b"],["class","absolute inset-x-0 bottom-0",4,"ngIf"],[1,"text-4xl","font-extrabold","tracking-tight","flex","items-baseline"],["svgIcon","heroicons_outline:chevron-left",1,"cursor-pointer","mr-2",3,"click"],[4,"ngIf","ngIfElse"],["createTitle",""],[1,"flex","flex-wrap","justify-center","shrink-0","items-start","sm:items-center","mt-6","lg:mt-0","lg:ml-4"],["mat-flat-button","",1,"ml-2","sm:ml-4","mb-3","lg:mb-0","min-w-50","sm:min-w-0",3,"color","click"],["svgIcon","heroicons_outline:document"],[1,"ml-2","mr-1"],[4,"ngIf"],[1,"flex","flex-col","overflow-auto"],[1,"flex","flex-col","py-8","px-6","md:px-8"],["multi",""],["expanded",""],[1,"border-t-2","border-t-primary","border-b",3,"collapsedHeight","expandedHeight"],[1,"text-2xl","font-bold","flex","items-center"],["svgIcon","heroicons_outline:information-circle"],[1,"py-3"],[1,"w-full"],["matInput","",3,"ngModel","ngModelChange"],["matInput","","type","password",3,"ngModel","ngModelChange"],[1,"flex","mb-5"],[1,"mr-3","font-medium"],[1,"flex","flex-col",3,"ngModel","color","ngModelChange"],["value","male",1,"mb-1"],["value","female"],[1,"w-full","flex-auto"],["matInput","",3,"matDatepicker"],["matSuffix","",3,"for"],["picker1",""],[1,"flex","items-center","h-6","min-h-6","mb-5","font-medium",3,"color","ngModel","ngModelChange"],["multiple","",3,"ngModel","ngModelChange"],[3,"value"],[3,"ngModel","ngModelChange"],[1,"absolute","inset-x-0","bottom-0"],[3,"mode"],[1,"flex","flex-col"],["mat-flat-button","",1,"ml-2","sm:ml-4","mb-3","lg:mb-0","min-w-50","sm:min-w-0","bg-green-500","mat-flat-button","mat-accent",3,"click"],["svgIcon","heroicons_outline:mail"],["svgIcon","heroicons_outline:trash"],["svgIcon","heroicons_outline:collection"],["mat-table","","matSort","",1,"w-full",3,"dataSource"],["ordersTableSort","matSort"],["matColumnDef","index"],["mat-header-cell","","mat-sort-header","",4,"matHeaderCellDef"],["mat-cell","",4,"matCellDef"],["matColumnDef","orderTotal"],["mat-header-cell","",4,"matHeaderCellDef"],["matColumnDef","orderStatus"],["matColumnDef","paymentStatus"],["matColumnDef","shippingStatus"],["matColumnDef","createdOn"],["matColumnDef","view"],["class","h-14","mat-header-row","",4,"matHeaderRowDef"],["class","h-15","mat-row","",4,"matRowDef","matRowDefColumns"],["showFirstLastButtons","",3,"pageSizeOptions"],["ordersPaginator",""],["mat-header-cell","","mat-sort-header",""],["mat-cell",""],["mat-header-cell",""],[1,"icon-size-5","mr-1","cursor-pointer",3,"svgIcon"],["mat-header-row","",1,"h-14"],["mat-row","",1,"h-15"]],template:function(t,o){if(1&t&&(e.TgZ(0,"div",0),e.TgZ(1,"div",1),e.YNc(2,se,2,1,"div",2),e.TgZ(3,"div",3),e.TgZ(4,"mat-icon",4),e.NdJ("click",function(){return o.back()}),e.qZA(),e.YNc(5,le,6,1,"ng-container",5),e.YNc(6,ce,1,0,"ng-template",null,6,e.W1O),e.qZA(),e.TgZ(8,"div",7),e.TgZ(9,"button",8),e.NdJ("click",function(){return o.saveAndRedirect()}),e._UZ(10,"mat-icon",9),e.TgZ(11,"span",10),e._uU(12,"Save"),e.qZA(),e.qZA(),e.TgZ(13,"button",8),e.NdJ("click",function(){return o.save()}),e._UZ(14,"mat-icon",9),e.TgZ(15,"span",10),e._uU(16,"Save and Continue Edit"),e.qZA(),e.qZA(),e.YNc(17,me,5,0,"ng-container",11),e.YNc(18,de,5,1,"ng-container",11),e.qZA(),e.qZA(),e.TgZ(19,"div",12),e.TgZ(20,"div",13),e.TgZ(21,"mat-accordion",14),e.TgZ(22,"mat-expansion-panel",15),e.TgZ(23,"mat-expansion-panel-header",16),e.TgZ(24,"mat-panel-title",17),e._UZ(25,"mat-icon",18),e._uU(26," \xa0 User info "),e.qZA(),e.qZA(),e.TgZ(27,"div",19),e.TgZ(28,"mat-form-field",20),e.TgZ(29,"mat-label"),e._uU(30,"Email"),e.qZA(),e.TgZ(31,"input",21),e.NdJ("ngModelChange",function(i){return o.user.info.email=i}),e.qZA(),e.qZA(),e.TgZ(32,"mat-form-field",20),e.TgZ(33,"mat-label"),e._uU(34,"Password"),e.qZA(),e.TgZ(35,"input",22),e.NdJ("ngModelChange",function(i){return o.user.info.password=i}),e.qZA(),e.qZA(),e.TgZ(36,"mat-form-field",20),e.TgZ(37,"mat-label"),e._uU(38,"First name"),e.qZA(),e.TgZ(39,"input",21),e.NdJ("ngModelChange",function(i){return o.user.info.first=i}),e.qZA(),e.qZA(),e.TgZ(40,"mat-form-field",20),e.TgZ(41,"mat-label"),e._uU(42,"Last name"),e.qZA(),e.TgZ(43,"input",21),e.NdJ("ngModelChange",function(i){return o.user.info.last=i}),e.qZA(),e.qZA(),e.TgZ(44,"div",23),e.TgZ(45,"mat-label",24),e._uU(46,"Gender"),e.qZA(),e.TgZ(47,"mat-radio-group",25),e.NdJ("ngModelChange",function(i){return o.user.info.gender=i}),e.TgZ(48,"mat-radio-button",26),e._uU(49,"Male"),e.qZA(),e.TgZ(50,"mat-radio-button",27),e._uU(51,"Female"),e.qZA(),e.qZA(),e.qZA(),e.TgZ(52,"mat-form-field",28),e.TgZ(53,"mat-label"),e._uU(54,"Date of birth"),e.qZA(),e._UZ(55,"input",29),e._UZ(56,"mat-datepicker-toggle",30),e._UZ(57,"mat-datepicker",null,31),e.qZA(),e.TgZ(59,"mat-form-field",20),e.TgZ(60,"mat-label"),e._uU(61,"Company name"),e.qZA(),e.TgZ(62,"input",21),e.NdJ("ngModelChange",function(i){return o.user.info.company=i}),e.qZA(),e.qZA(),e.TgZ(63,"mat-checkbox",32),e.NdJ("ngModelChange",function(i){return o.user.info.tax=i}),e._uU(64," Is tax exempt "),e.qZA(),e.TgZ(65,"mat-form-field",20),e.TgZ(66,"mat-label"),e._uU(67,"Newsletter"),e.qZA(),e.TgZ(68,"input",21),e.NdJ("ngModelChange",function(i){return o.user.info.newsletter=i}),e.qZA(),e.qZA(),e.TgZ(69,"mat-form-field",20),e.TgZ(70,"mat-label"),e._uU(71,"User roles"),e.qZA(),e.TgZ(72,"mat-select",33),e.NdJ("ngModelChange",function(i){return o.user.info.roles=i}),e.TgZ(73,"mat-option",34),e._uU(74,"Registered"),e.qZA(),e.TgZ(75,"mat-option",34),e._uU(76,"Forum Moderators"),e.qZA(),e.TgZ(77,"mat-option",34),e._uU(78,"Administrators"),e.qZA(),e.TgZ(79,"mat-option",34),e._uU(80,"Guests"),e.qZA(),e.TgZ(81,"mat-option",34),e._uU(82,"Vendors"),e.qZA(),e.qZA(),e.qZA(),e.TgZ(83,"mat-form-field",20),e.TgZ(84,"mat-label"),e._uU(85,"Manager of vendor"),e.qZA(),e.TgZ(86,"mat-select",35),e.NdJ("ngModelChange",function(i){return o.user.info.vendor=i}),e.TgZ(87,"mat-option",34),e._uU(88,"Not a vendor"),e.qZA(),e.TgZ(89,"mat-option",34),e._uU(90,"Vendor 1"),e.qZA(),e.TgZ(91,"mat-option",34),e._uU(92,"Vendor 2"),e.qZA(),e.qZA(),e.TgZ(93,"mat-hint"),e._uU(94,'Note: if you have a vendor associated with this user, then also ensure it is in "Vendors" user role..'),e.qZA(),e.qZA(),e.TgZ(95,"mat-checkbox",32),e.NdJ("ngModelChange",function(i){return o.user.info.active=i}),e._uU(96," Active "),e.qZA(),e.TgZ(97,"mat-form-field",20),e.TgZ(98,"mat-label"),e._uU(99,"Admin comment"),e.qZA(),e.TgZ(100,"textarea",21),e.NdJ("ngModelChange",function(i){return o.user.info.adminComment=i}),e.qZA(),e.qZA(),e.qZA(),e.qZA(),e.YNc(101,Je,8,3,"ng-container",11),e.qZA(),e.qZA(),e.qZA(),e.qZA()),2&t){const a=e.MAs(7),i=e.MAs(58);e.xp6(2),e.Q6J("ngIf",o.isLoading),e.xp6(3),e.Q6J("ngIf",o.isEdit)("ngIfElse",a),e.xp6(4),e.Q6J("color","primary"),e.xp6(4),e.Q6J("color","primary"),e.xp6(4),e.Q6J("ngIf",o.isEdit),e.xp6(1),e.Q6J("ngIf",o.isEdit),e.xp6(5),e.Q6J("collapsedHeight","60px")("expandedHeight","60px"),e.xp6(8),e.Q6J("ngModel",o.user.info.email),e.xp6(4),e.Q6J("ngModel",o.user.info.password),e.xp6(4),e.Q6J("ngModel",o.user.info.first),e.xp6(4),e.Q6J("ngModel",o.user.info.last),e.xp6(4),e.Q6J("ngModel",o.user.info.gender)("color","primary"),e.xp6(8),e.Q6J("matDatepicker",i),e.xp6(1),e.Q6J("for",i),e.xp6(6),e.Q6J("ngModel",o.user.info.company),e.xp6(1),e.Q6J("color","primary")("ngModel",o.user.info.tax),e.xp6(5),e.Q6J("ngModel",o.user.info.newsletter),e.xp6(4),e.Q6J("ngModel",o.user.info.roles),e.xp6(1),e.Q6J("value","value1"),e.xp6(2),e.Q6J("value","value2"),e.xp6(2),e.Q6J("value","value3"),e.xp6(2),e.Q6J("value","value4"),e.xp6(2),e.Q6J("value","value5"),e.xp6(5),e.Q6J("ngModel",o.user.info.vendor),e.xp6(1),e.Q6J("value","value1"),e.xp6(2),e.Q6J("value","value4"),e.xp6(2),e.Q6J("value","value5"),e.xp6(4),e.Q6J("color","primary")("ngModel",o.user.info.active),e.xp6(5),e.Q6J("ngModel",o.user.info.adminComment),e.xp6(1),e.Q6J("ngIf",o.isEdit)}},directives:[C.O5,A.Hw,x.lW,c.pp,c.ib,c.yz,c.yK,m.KE,m.hX,U.Nt,g.Fj,g.JJ,g.On,y.VQ,y.U0,T.hl,T.nW,m.R9,T.Mq,M.oG,v.gD,d.ey,m.bx,b.pW,l.BZ,_.YE,l.w1,l.fO,l.Dz,l.as,l.nj,h.NW,l.ge,_.nU,l.ev,l.XQ,l.Gk],encapsulation:2}),n})();var E=s(5439);const p=E||s.t(E,2),N=new e.OlP("MAT_MOMENT_DATE_ADAPTER_OPTIONS",{providedIn:"root",factory:function(){return{useUtc:!1}}});function Qe(n,r){const t=Array(n);for(let o=0;o<n;o++)t[o]=r(o);return t}let Se=(()=>{class n extends d._A{constructor(t,o){super(),this._options=o,this.setLocale(t||p.locale())}setLocale(t){super.setLocale(t);let o=p.localeData(t);this._localeData={firstDayOfWeek:o.firstDayOfWeek(),longMonths:o.months(),shortMonths:o.monthsShort(),dates:Qe(31,a=>this.createDate(2017,0,a+1).format("D")),longDaysOfWeek:o.weekdays(),shortDaysOfWeek:o.weekdaysShort(),narrowDaysOfWeek:o.weekdaysMin()}}getYear(t){return this.clone(t).year()}getMonth(t){return this.clone(t).month()}getDate(t){return this.clone(t).date()}getDayOfWeek(t){return this.clone(t).day()}getMonthNames(t){return"long"==t?this._localeData.longMonths:this._localeData.shortMonths}getDateNames(){return this._localeData.dates}getDayOfWeekNames(t){return"long"==t?this._localeData.longDaysOfWeek:"short"==t?this._localeData.shortDaysOfWeek:this._localeData.narrowDaysOfWeek}getYearName(t){return this.clone(t).format("YYYY")}getFirstDayOfWeek(){return this._localeData.firstDayOfWeek}getNumDaysInMonth(t){return this.clone(t).daysInMonth()}clone(t){return t.clone().locale(this.locale)}createDate(t,o,a){const i=this._createMoment({year:t,month:o,date:a}).locale(this.locale);return i.isValid(),i}today(){return this._createMoment().locale(this.locale)}parse(t,o){return t&&"string"==typeof t?this._createMoment(t,o,this.locale):t?this._createMoment(t).locale(this.locale):null}format(t,o){return t=this.clone(t),this.isValid(t),t.format(o)}addCalendarYears(t,o){return this.clone(t).add({years:o})}addCalendarMonths(t,o){return this.clone(t).add({months:o})}addCalendarDays(t,o){return this.clone(t).add({days:o})}toIso8601(t){return this.clone(t).format()}deserialize(t){let o;if(t instanceof Date)o=this._createMoment(t).locale(this.locale);else if(this.isDateInstance(t))return this.clone(t);if("string"==typeof t){if(!t)return null;o=this._createMoment(t,p.ISO_8601).locale(this.locale)}return o&&this.isValid(o)?this._createMoment(o).locale(this.locale):super.deserialize(t)}isDateInstance(t){return p.isMoment(t)}isValid(t){return this.clone(t).isValid()}invalid(){return p.invalid()}_createMoment(t,o,a){const{strict:i,useUtc:u}=this._options||{};return u?p.utc(t,o,a,i):p(t,o,a,i)}}return n.\u0275fac=function(t){return new(t||n)(e.LFG(d.Ad,8),e.LFG(N,8))},n.\u0275prov=e.Yz7({token:n,factory:n.\u0275fac}),n})();const we={parse:{dateInput:"l"},display:{dateInput:"l",monthYearLabel:"MMM YYYY",dateA11yLabel:"LL",monthYearA11yLabel:"MMMM YYYY"}};let ke=(()=>{class n{}return n.\u0275fac=function(t){return new(t||n)},n.\u0275mod=e.oAB({type:n}),n.\u0275inj=e.cJS({providers:[{provide:d._A,useClass:Se,deps:[d.Ad,N]}]}),n})(),Ye=(()=>{class n{}return n.\u0275fac=function(t){return new(t||n)},n.\u0275mod=e.oAB({type:n}),n.\u0275inj=e.cJS({providers:[{provide:d.sG,useValue:we}],imports:[[ke]]}),n})();const Ie=[{path:"",component:te},{path:"create",component:J},{path:"edit/:id",component:J,data:{isEdit:!0}}];let Oe=(()=>{class n{}return n.\u0275fac=function(t){return new(t||n)},n.\u0275mod=e.oAB({type:n}),n.\u0275inj=e.cJS({imports:[[A.Ps,Z.Tx,m.lN,x.ot,y.Fk,T.FA,Ye,l.p0,M.p9,h.TU,b.Cv,v.LD,U.c,d.si,_.JX,ne.rP,c.To,oe.UM,C.ez,re.m,f.Bz.forChild(Ie)]]}),n})()}}]);
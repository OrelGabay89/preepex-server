import { AfterViewInit, Component, OnInit, TemplateRef, ViewChild, ViewEncapsulation } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Router } from '@angular/router';
import { FuseConfirmationService } from '@fuse/services/confirmation';
import { AngularEditorConfig } from '@kolkov/angular-editor';

export type ProductOptions = {
  id: string;
  name: string;
  publish: boolean;
  isSelected: boolean;
  featured: boolean;
  order: number;
};

@Component({
  selector: 'app-category-creator-editor',
  templateUrl: './category-creator-editor.component.html',
  encapsulation: ViewEncapsulation.None
})
export class CategoryCreatorEditorComponent implements OnInit, AfterViewInit {

  @ViewChild('prodctPaginator') prodctPaginator: MatPaginator;
  @ViewChild('selectedProductPaginator') selectedProductPaginator: MatPaginator;

  @ViewChild('productTableSort') productTableSort: MatSort;
  @ViewChild('selectedProductTableSort') selectedProductTableSort: MatSort;

  isEdit: boolean;
  categoryId: string;
  isLoading: boolean;
  category = {
    isAdvanced: true,
    info: {
      name: '',
      description: '',
      parentCategory: '',
      picture: null
    },
    display: {
      isPublished: true,
      showOnHomePage: false,
      includeInTopMenu: true,
      allowSelectPageSize: true,
      pageSize: 6,
      pageSizeOption: '6, 3, 9',
      allowPriceRangeFilter: true,
      allowManualPrice: true,
      priceFrom: 3,
      priceTo: 10000,
      order: 0,
      categoryTemplate: ''
    }
  }; // todo:: define type

  editorConfig: AngularEditorConfig = {
    editable: true,
    spellcheck: true,
    height: 'auto',
    minHeight: '200',
    maxHeight: 'auto',
    width: 'auto',
    minWidth: '0',
    translate: 'yes',
    enableToolbar: true,
    showToolbar: true,
    placeholder: 'Enter text here...',
    defaultParagraphSeparator: '',
    defaultFontName: '',
    defaultFontSize: '',
    fonts: [
      { class: 'arial', name: 'Arial' },
      { class: 'times-new-roman', name: 'Times New Roman' },
      { class: 'calibri', name: 'Calibri' },
      { class: 'comic-sans-ms', name: 'Comic Sans MS' }
    ],
    toolbarPosition: 'top',
    toolbarHiddenButtons: [
      ['subscript',
        'superscript', 'heading',],
      ['backgroundColor',
        'customClasses',
        'link',
        'unlink',
        'insertImage',
        'insertVideo',
        'insertHorizontalRule',
        'toggleEditorMode']
    ]
  };


  public isAllSelected: boolean;
  products = [
    {
      id: 'b899ec30-b85a-40ab-bb1f-18a596d5c6de',
      name: 'Build your own computer',
      publish: true,
      isSelected: false,
      featured: false,
      order: 1
    },
    {
      id: 'b899ec33-b85a-40ab-bb1f-18a596d5c6de',
      name: 'Asus N551JK-XO076H Laptop',
      publish: true,
      isSelected: false,
      featured: false,
      order: 1
    },
    {
      id: 'b899ec30-b85a-40ab-bb1t-18a596d5c6de',
      name: 'HP Spectre XT Pro UltraBook',
      publish: true,
      isSelected: false,
      featured: false,
      order: 1
    },
    {
      id: 'b899ec30-b85a-40ab-bb1f-18a596d5d6de',
      name: 'Lenovo IdeaCentre 600 All-in-One PC',
      publish: true,
      isSelected: false,
      featured: false,
      order: 1
    },
    {
      id: 'b899ec30-g85a-40ab-bb1f-18a596d5c6de',
      name: 'Digital Storm VANQUISH 3 Custom Performance PC',
      publish: true,
      isSelected: false,
      featured: false,
      order: 1
    },
    {
      id: 'b899ec33-b85a-40ab-bb1f-18a566d5c6de',
      name: 'Asus N551JK-XO076H Laptop 2',
      publish: true,
      isSelected: false,
      featured: false,
      order: 2
    },
    {
      id: 'b899ec30-b83a-40ab-bb1t-18a596d5c6de',
      name: 'HP Spectre XT Pro UltraBook 4',
      publish: true,
      isSelected: false,
      featured: false,
      order: 9
    },
    {
      id: 'b899ec30-b85a-40ab-yb1f-18a596d5d6de',
      name: 'Lenovo IdeaCentre 600 All-in-One PC 1',
      publish: true,
      isSelected: false,
      featured: false,
      order: 5
    },
  ];
  selectedProducts = [];

  productsDataSource = new MatTableDataSource<ProductOptions>(this.products);
  selectedProductsDataSource = new MatTableDataSource<any>();

  public productsDisplayedColumns: string[] = ['select', 'name', 'publish'];
  public selectedProductsDisplayedColumns: string[] = ['name', 'featured', 'order', 'actions'];

  constructor(private _route: ActivatedRoute,
    private matDialog: MatDialog,
    private _router: Router,
    private _fuseConfirmationService: FuseConfirmationService) {
    const snapshot = this._route.snapshot;
    this.isEdit = snapshot?.data.isEdit;
    if (this.isEdit) {
      this.categoryId = snapshot.params.id;
    }
  }

  ngOnInit(): void {
    if (this.isEdit) {
      // fetch data from api for this.categoryId - to preselect the data
      this.category.info.name = 'MEN\'S FASHION';
    }

    this.productsDataSource.data = this.products;
  }

  ngAfterViewInit(): void {
    this.selectedProductsDataSource.paginator = this.selectedProductPaginator;
    this.selectedProductsDataSource.sort = this.selectedProductTableSort;
  }

  back(): void {
    if (this.isEdit) {
      this._router.navigate(['../..'], { relativeTo: this._route });
    } else {
      this._router.navigate(['..'], { relativeTo: this._route });
    }
  }

  save(): void {
    this.categoryId = 'b899ec30-b85a-40ab-bb1f-18a596d5c6de';
    this.isEdit = true;
  }

  saveAndRedirect(): void {
    this.back();
  }

  openProductTable(ref: TemplateRef<any>): void {
    this.matDialog.open(ref, {
      width: '80vw',
      maxHeight: '90vh'
    });

    setTimeout(() => {
      this.productsDataSource.sort = this.productTableSort;
      this.productsDataSource.paginator = this.prodctPaginator;
    });
  }

  masterToggle(event): void {
    if (event.checked) {
      this.products.forEach(x => x.isSelected = true);
    } else {
      this.products.forEach(x => x.isSelected = false);
    }
  }

  toggleSelect(event, element): void {
    const foundProduct = this.products.find(product => product.id === element.id);
    foundProduct.isSelected = event.checked;
    this.isAllSelected = this.products.every(product => product.isSelected);
  }

  saveProducts(): void {
    this.selectedProducts = [...this.selectedProducts, ...this.products.filter(p => p.isSelected)];
    this.selectedProducts.forEach(p => p.isSelected = false);
    this.selectedProductsDataSource.data = this.selectedProducts;

    // remove selected from products
    this.selectedProducts.forEach((product) => {
      const index = this.products.findIndex(p => p.id === product.id);
      if (index > -1) {
        this.products.splice(index, 1);
      }
    });

    this.productsDataSource.data = this.products;

    this.matDialog.closeAll();
  }

  deleteSelectedProduct(productId: string): void {
    this.products = [...this.products, this.selectedProducts.find(p => p.id === productId)];
    this.productsDataSource.data = this.products;

    const index = this.selectedProducts.findIndex(p => p.id === productId);
    if (index > -1) {
      this.selectedProducts.splice(index, 1);
    }
    this.selectedProductsDataSource.data = this.selectedProducts;
  }

  deleteCategory(): void {
    const confirmation = this._fuseConfirmationService.open({
      title: 'Delete category',
      message: 'Are you sure you want to remove this category? This action cannot be undone!',
      actions: {
        confirm: {
          label: 'Delete'
        }
      }
    });

    // Subscribe to the confirmation dialog closed action
    confirmation.afterClosed().subscribe((result) => {

      // If the confirm button pressed...
      if (result === 'confirmed') {
        // delete brand
        this.back();
      }
    });
  }

  onFileDropped(data): void {
  }

  fileBrowseHandler(files): void {
    this.category.info.picture = files[0];
  }

  clearSearchFilter(): void {

  }
}

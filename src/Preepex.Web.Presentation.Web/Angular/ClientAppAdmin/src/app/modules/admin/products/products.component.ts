import { AfterViewInit, ChangeDetectionStrategy, ChangeDetectorRef, Component, OnDestroy, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatCheckboxChange } from '@angular/material/checkbox';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { fuseAnimations } from '@fuse/animations';
import { FuseConfirmationService } from '@fuse/services/confirmation';
import { BehaviorSubject, combineLatest, debounceTime, map, merge, Observable, Subject, switchMap, takeUntil } from 'rxjs';
import { InventoryService } from './inventory.service';
import { InventoryProduct, InventoryBrand, InventoryCategory, InventoryTag, InventoryPagination, InventoryVendor, InventoryLabel } from './inventory.types';
import { AngularEditorConfig } from '@kolkov/angular-editor';
import { tap } from 'lodash';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styles: [
    `
    .inventory-grid {
        grid-template-columns: 48px auto 40px;
        @screen sm {
            grid-template-columns: 48px auto 112px 72px;
        }
        @screen md {
            grid-template-columns: 48px 112px auto 112px 72px;
        }
        @screen lg {
            grid-template-columns: 48px 112px auto 112px 96px 96px 72px;
        }
    }`
  ],
  encapsulation: ViewEncapsulation.None,
  changeDetection: ChangeDetectionStrategy.OnPush,
  animations: fuseAnimations
})
export class ProductsComponent implements OnInit, AfterViewInit, OnDestroy {

  @ViewChild(MatPaginator) private _paginator: MatPaginator;
  @ViewChild(MatSort) private _sort: MatSort;

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

  imageFiles: any[] = [];
  videoFiles: any[] = [];
  products$: Observable<InventoryProduct[]>;
  brands: InventoryBrand[];
  categories: InventoryCategory[];
  filteredTags: InventoryTag[];
  filteredLabels: InventoryLabel[];
  flashMessage: 'success' | 'error' | null = null;
  isLoading: boolean = false;
  pagination: InventoryPagination;
  searchInputControl: FormControl = new FormControl();
  selectedProduct: InventoryProduct | null = null;
  selectedProductForm: FormGroup;
  tags: InventoryTag[];
  labels: InventoryLabel[];
  tagsEditMode: boolean = false;
  labelsEditMode: boolean = false;
  vendors: InventoryVendor[];
  paymentsArray = Array.from(Array(24).keys());
  filterValues = {
    name: '',
    category: 'all',
    brand: 'all',
    published: 'all',
    vendor: 'all',
    sku: ''
  };
  filterValues$ = new BehaviorSubject(this.filterValues);
  private _unsubscribeAll: Subject<any> = new Subject<any>();


  /**
   * Constructor
   */
  constructor(
    private _changeDetectorRef: ChangeDetectorRef,
    private _fuseConfirmationService: FuseConfirmationService,
    private _formBuilder: FormBuilder,
    private _inventoryService: InventoryService
  ) {
  }

  // -----------------------------------------------------------------------------------------------------
  // @ Lifecycle hooks
  // -----------------------------------------------------------------------------------------------------

  /**
   * On init
   */
  ngOnInit(): void {
    // Create the selected product form
    this.selectedProductForm = this._formBuilder.group({
      id: [''],
      category: [''],
      name: ['', [Validators.required]],
      description: [''],
      tags: [[]],
      labels: [[]],
      sku: [''],
      barcode: [''],
      brand: [''],
      vendor: [''],
      stock: [''],
      reserved: [''],
      cost: [''],
      basePrice: [''],
      taxPercent: [''],
      price: [''],
      shipping: [''],
      expressShipping: [''],
      deliveryTime: [''],
      payments: [''],
      customerNotes: [''],
      shortDescription: [''],
      longDescription: [''],
      thumbnail: [''],
      images: [[]],
      currentImageIndex: [0], // Image index that is currently being viewed
      active: [false]
    });

    // Get the brands
    this._inventoryService.brands$
      .pipe(takeUntil(this._unsubscribeAll))
      .subscribe((brands: InventoryBrand[]) => {

        // Update the brands
        this.brands = brands;

        // Mark for check
        this._changeDetectorRef.markForCheck();
      });

    // Get the categories
    this._inventoryService.categories$
      .pipe(takeUntil(this._unsubscribeAll))
      .subscribe((categories: InventoryCategory[]) => {

        // Update the categories
        this.categories = categories;

        // Mark for check
        this._changeDetectorRef.markForCheck();
      });

    // Get the products
    this.products$ = combineLatest([this._inventoryService.products$, this.filterValues$]).pipe(
      map(([products, filtervalues]) => {


        if (filtervalues.name) {
          products = products.filter(p => p.name.toLowerCase().includes(filtervalues.name.toLowerCase()));
        }

        if (filtervalues.category && filtervalues.category !== 'all') {
          products = products.filter(p => p.category === filtervalues.category);
        }

        if (filtervalues.brand && filtervalues.brand !== 'all') {
          products = products.filter(p => p.brand === filtervalues.brand);
        }

        if (filtervalues.vendor && filtervalues.vendor !== 'all') {
          products = products.filter(p => p.vendor === filtervalues.vendor);
        }

        if (filtervalues.sku) {
          products = products.filter(p => p.sku === filtervalues.sku);
        }

        this.pagination = {...this.pagination, length: products.length, page: 0};
        return products;
      })
    );

    this._inventoryService.pagination$
      .pipe(takeUntil(this._unsubscribeAll))
      .subscribe((pagination: InventoryPagination) => {

        // Update the pagination
        this.pagination = pagination;

        // Mark for check
        this._changeDetectorRef.markForCheck();
      });

    // Get the tags
    this._inventoryService.tags$
      .pipe(takeUntil(this._unsubscribeAll))
      .subscribe((tags: InventoryTag[]) => {

        // Update the tags
        this.tags = tags;
        this.filteredTags = tags;

        // Mark for check
        this._changeDetectorRef.markForCheck();
      });

    // Get the labels
    this._inventoryService.labels$
      .pipe(takeUntil(this._unsubscribeAll))
      .subscribe((labels: InventoryLabel[]) => {

        this.labels = labels;
        this.filteredLabels = labels;

        this._changeDetectorRef.markForCheck();
      });

    // Get the vendors
    this._inventoryService.vendors$
      .pipe(takeUntil(this._unsubscribeAll))
      .subscribe((vendors: InventoryVendor[]) => {

        // Update the vendors
        this.vendors = vendors;

        // Mark for check
        this._changeDetectorRef.markForCheck();
      });

    // Subscribe to search input field value changes
    this.searchInputControl.valueChanges
      .pipe(
        takeUntil(this._unsubscribeAll),
        debounceTime(300),
        switchMap((query) => {
          this.closeDetails();
          this.isLoading = true;
          return this._inventoryService.getProducts(0, 10, 'name', 'asc', query);
        }),
        map(() => {
          this.isLoading = false;
        })
      )
      .subscribe();
  }

  /**
   * After view init
   */
  ngAfterViewInit(): void {
    if (this._sort && this._paginator) {
      // Set the initial sort
      this._sort.sort({
        id: 'name',
        start: 'asc',
        disableClear: true
      });

      // Mark for check
      this._changeDetectorRef.markForCheck();

      // If the user changes the sort order...
      this._sort.sortChange
        .pipe(takeUntil(this._unsubscribeAll))
        .subscribe(() => {
          // Reset back to the first page
          this._paginator.pageIndex = 0;

          // Close the details
          this.closeDetails();
        });

      // Get products if sort or page changes
      merge(this._sort.sortChange, this._paginator.page).pipe(
        switchMap(() => {
          this.closeDetails();
          this.isLoading = true;
          return this._inventoryService.getProducts(this._paginator.pageIndex, this._paginator.pageSize, this._sort.active, this._sort.direction);
        }),
        map(() => {
          this.isLoading = false;
        })
      ).subscribe();
    }
  }

  /**
   * On destroy
   */
  ngOnDestroy(): void {
    // Unsubscribe from all subscriptions
    this._unsubscribeAll.next(null);
    this._unsubscribeAll.complete();
  }

  // -----------------------------------------------------------------------------------------------------
  // @ Public methods
  // -----------------------------------------------------------------------------------------------------

  filterData(): void {
    this.filterValues$.next(this.filterValues);
  }

  clearSearchFilter(): void {
    this.filterValues =  {
      name: '',
      category: 'all',
      brand: 'all',
      published: 'all',
      vendor: 'all',
      sku: ''
    };
    this.filterValues$.next(this.filterValues);
  }

  onFileDropped($event): void {
    this.prepareFilesList($event);
  }

  // handle file from browsing
  fileBrowseHandler(files): void {
    this.prepareFilesList(files);
  }

  // Delete file from files list
  onDeleteClick(index: number): void {
    this.imageFiles.splice(index, 1);
  }

  // Simulate the upload process
  uploadFilesSimulator(index: number): void {
    setTimeout(() => {
      if (index === this.imageFiles.length) {
        return;
      } else {
        const progressInterval = setInterval(() => {
          if (this.imageFiles[index]) {
            if (this.imageFiles[index].progress === 100) {
              clearInterval(progressInterval);
              this.uploadFilesSimulator(index + 1);
            } else {
              this.imageFiles[index].progress += 5;
            }
          }
        }, 200);
      }
    }, 1000);
  }

  // Convert Files list to normal array list
  prepareFilesList(files: Array<any>): void {
    for (const item of files) {
      item.progress = 0;
      this.imageFiles.unshift(item);
    }
    this.uploadFilesSimulator(0);
  }

  // Video Files

  onVideoFileDropped($event): void {
    this.prepareVideoFilesList($event);
  }

  // handle file from browsing
  fileVideoBrowseHandler(files): void {
    this.prepareVideoFilesList(files);
  }

  // Delete file from files list
  onDeleteVideoClick(index: number): void {
    this.videoFiles.splice(index, 1);
  }

  // Simulate the upload process
  uploadVideoFilesSimulator(index: number): void {
    setTimeout(() => {
      if (index === this.videoFiles.length) {
        return;
      } else {
        const progressInterval = setInterval(() => {
          if (this.videoFiles[index]) {
            if (this.videoFiles[index].progress === 100) {
              clearInterval(progressInterval);
              this.uploadVideoFilesSimulator(index + 1);
            } else {
              this.videoFiles[index].progress += 5;
            }
          }
        }, 200);
      }
    }, 1000);
  }

  // Convert Files list to normal array list
  prepareVideoFilesList(files: Array<any>): void {
    for (const item of files) {
      item.progress = 0;
      this.videoFiles.unshift(item);
    }
    this.uploadFilesSimulator(0);
  }

  /**
   * Toggle product details
   *
   * @param productId
   */
  toggleDetails(productId: string): void {
    // If the product is already selected...
    if (this.selectedProduct && this.selectedProduct.id === productId) {
      // Close the details
      this.closeDetails();
      return;
    }

    // Get the product by id
    this._inventoryService.getProductById(productId)
      .subscribe((product) => {

        // Set the selected product
        this.selectedProduct = product;

        // Fill the form
        this.selectedProductForm.patchValue(product);

        // Mark for check
        this._changeDetectorRef.markForCheck();
      });
  }

  /**
   * Close the details
   */
  closeDetails(): void {
    this.selectedProduct = null;
  }

  /**
   * Cycle through images of selected product
   */
  cycleImages(forward: boolean = true): void {
    // Get the image count and current image index
    const count = this.selectedProductForm.get('images').value.length;
    const currentIndex = this.selectedProductForm.get('currentImageIndex').value;

    // Calculate the next and previous index
    const nextIndex = currentIndex + 1 === count ? 0 : currentIndex + 1;
    const prevIndex = currentIndex - 1 < 0 ? count - 1 : currentIndex - 1;

    // If cycling forward...
    if (forward) {
      this.selectedProductForm.get('currentImageIndex').setValue(nextIndex);
    }
    // If cycling backwards...
    else {
      this.selectedProductForm.get('currentImageIndex').setValue(prevIndex);
    }
  }

  /**
   * Toggle the tags edit mode
   */
  toggleTagsEditMode(): void {
    this.tagsEditMode = !this.tagsEditMode;
  }
  toggleLabelsEditMode(): void {
    this.labelsEditMode = !this.labelsEditMode;
  }

  /**
   * Filter tags
   *
   * @param event
   */
  filterTags(event): void {
    // Get the value
    const value = event.target.value.toLowerCase();

    // Filter the tags
    this.filteredTags = this.tags.filter(tag => tag.title.toLowerCase().includes(value));
  }

  filterLabels(event): void {
    // Get the value
    const value = event.target.value.toLowerCase();

    // Filter the labels
    this.filteredLabels = this.labels.filter(label => label.title.toLowerCase().includes(value));
  }

  /**
   * Filter tags input key down event
   *
   * @param event
   */
  filterTagsInputKeyDown(event): void {
    // Return if the pressed key is not 'Enter'
    if (event.key !== 'Enter') {
      return;
    }

    // If there is no tag available...
    if (this.filteredTags.length === 0) {
      // Create the tag
      this.createTag(event.target.value);

      // Clear the input
      event.target.value = '';

      // Return
      return;
    }

    // If there is a tag...
    const tag = this.filteredTags[0];
    const isTagApplied = this.selectedProduct.tags.find(id => id === tag.id);

    // If the found tag is already applied to the product...
    if (isTagApplied) {
      // Remove the tag from the product
      this.removeTagFromProduct(tag);
    }
    else {
      // Otherwise add the tag to the product
      this.addTagToProduct(tag);
    }
  }

  filterLabelsInputKeyDown(event): void {
    if (event.key !== 'Enter') {
      return;
    }

    if (this.filteredLabels.length === 0) {
      this.createLabel(event.target.value);

      event.target.value = '';

      return;
    }

    const label = this.filteredLabels[0];
    const isLabelApplied = this.selectedProduct.labels.find(id => id === label.id);

    if (isLabelApplied) {
      this.removeLabelFromProduct(label);
    }
    else {
      this.addLabelToProduct(label);
    }
  }

  /**
   * Create a new tag
   *
   * @param title
   */
  createTag(title: string): void {
    const tag = {
      title
    };

    // Create tag on the server
    this._inventoryService.createTag(tag)
      .subscribe((response) => {

        // Add the tag to the product
        this.addTagToProduct(response);
      });
  }
  createLabel(title: string): void {
    const label = {
      title
    };

    this._inventoryService.createLabel(label)
      .subscribe((response) => {

        this.addLabelToProduct(response);
      });
  }

  /**
   * Update the tag title
   *
   * @param tag
   * @param event
   */
  updateTagTitle(tag: InventoryTag, event): void {
    // Update the title on the tag
    tag.title = event.target.value;

    // Update the tag on the server
    this._inventoryService.updateTag(tag.id, tag)
      .pipe(debounceTime(300))
      .subscribe();

    // Mark for check
    this._changeDetectorRef.markForCheck();
  }
  updateLabelTitle(label: InventoryLabel, event): void {
    // Update the title on the label
    label.title = event.target.value;

    // Update the label on the server
    this._inventoryService.updateLabel(label.id, label)
      .pipe(debounceTime(300))
      .subscribe();

    // Mark for check
    this._changeDetectorRef.markForCheck();
  }

  /**
   * Delete the tag
   *
   * @param tag
   */
  deleteTag(tag: InventoryTag): void {
    // Delete the tag from the server
    this._inventoryService.deleteTag(tag.id).subscribe();

    // Mark for check
    this._changeDetectorRef.markForCheck();
  }
  deleteLabel(label: InventoryLabel): void {
    // Delete the label from the server
    this._inventoryService.deleteLabel(label.id).subscribe();

    // Mark for check
    this._changeDetectorRef.markForCheck();
  }

  /**
   * Add tag to the product
   *
   * @param tag
   */
  addTagToProduct(tag: InventoryTag): void {
    // Add the tag
    this.selectedProduct.tags.unshift(tag.id);

    // Update the selected product form
    this.selectedProductForm.get('tags').patchValue(this.selectedProduct.tags);

    // Mark for check
    this._changeDetectorRef.markForCheck();
  }

  addLabelToProduct(label: InventoryLabel): void {
    // Add the label
    this.selectedProduct.labels.unshift(label.id);

    // Update the selected product form
    this.selectedProductForm.get('labels').patchValue(this.selectedProduct.labels);

    // Mark for check
    this._changeDetectorRef.markForCheck();
  }

  /**
   * Remove tag from the product
   *
   * @param tag
   */
  removeTagFromProduct(tag: InventoryTag): void {
    // Remove the tag
    this.selectedProduct.tags.splice(this.selectedProduct.tags.findIndex(item => item === tag.id), 1);

    // Update the selected product form
    this.selectedProductForm.get('tags').patchValue(this.selectedProduct.tags);

    // Mark for check
    this._changeDetectorRef.markForCheck();
  }

  removeLabelFromProduct(label: InventoryLabel): void {
    // Remove the label
    this.selectedProduct.labels.splice(this.selectedProduct.labels.findIndex(item => item === label.id), 1);

    // Update the selected product form
    this.selectedProductForm.get('labels').patchValue(this.selectedProduct.labels);

    // Mark for check
    this._changeDetectorRef.markForCheck();
  }

  /**
   * Toggle product tag
   *
   * @param tag
   * @param change
   */
  toggleProductTag(tag: InventoryTag, change: MatCheckboxChange): void {
    if (change.checked) {
      this.addTagToProduct(tag);
    }
    else {
      this.removeTagFromProduct(tag);
    }
  }

  toggleProductLabel(label: InventoryLabel, change: MatCheckboxChange): void {
    if (change.checked) {
      this.addLabelToProduct(label);
    }
    else {
      this.removeLabelFromProduct(label);
    }
  }

  /**
   * Should the create tag button be visible
   *
   * @param inputValue
   */
  shouldShowCreateTagButton(inputValue: string): boolean {
    return !!!(inputValue === '' || this.tags.findIndex(tag => tag.title.toLowerCase() === inputValue.toLowerCase()) > -1);
  }

  shouldShowCreateLabelButton(inputValue: string): boolean {
    return !!!(inputValue === '' || this.labels.findIndex(label => label.title.toLowerCase() === inputValue.toLowerCase()) > -1);
  }

  /**
   * Create product
   */
  createProduct(): void {
    // Create the product
    this._inventoryService.createProduct().subscribe((newProduct) => {

      // Go to new product
      this.selectedProduct = newProduct;

      // Fill the form
      this.selectedProductForm.patchValue(newProduct);

      // Mark for check
      this._changeDetectorRef.markForCheck();
    });
  }

  /**
   * Update the selected product using the form data
   */
  updateSelectedProduct(): void {
    // Get the product object
    const product = this.selectedProductForm.getRawValue();

    // Remove the currentImageIndex field
    delete product.currentImageIndex;

    // Update the product on the server
    this._inventoryService.updateProduct(product.id, product).subscribe(() => {

      // Show a success message
      this.showFlashMessage('success');
    });
  }

  /**
   * Delete the selected product using the form data
   */
  deleteSelectedProduct(): void {
    // Open the confirmation dialog
    const confirmation = this._fuseConfirmationService.open({
      title: 'Delete product',
      message: 'Are you sure you want to remove this product? This action cannot be undone!',
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

        // Get the product object
        const product = this.selectedProductForm.getRawValue();

        // Delete the product on the server
        this._inventoryService.deleteProduct(product.id).subscribe(() => {

          // Close the details
          this.closeDetails();
        });
      }
    });
  }

  /**
   * Show flash message
   */
  showFlashMessage(type: 'success' | 'error'): void {
    // Show the message
    this.flashMessage = type;

    // Mark for check
    this._changeDetectorRef.markForCheck();

    // Hide it after 3 seconds
    setTimeout(() => {

      this.flashMessage = null;

      // Mark for check
      this._changeDetectorRef.markForCheck();
    }, 3000);
  }

  /**
   * Track by function for ngFor loops
   *
   * @param index
   * @param item
   */
  trackByFn(index: number, item: any): any {
    return item.id || index;
  }

}

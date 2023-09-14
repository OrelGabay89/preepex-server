import { ChangeDetectionStrategy, ChangeDetectorRef, Component, OnDestroy, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { MatDrawer } from '@angular/material/sidenav';
import { FuseMediaWatcherService } from '@fuse/services/media-watcher';
import { Subject, takeUntil } from 'rxjs';

@Component({
  selector: 'app-homepage-settings',
  templateUrl: './homepage-settings.component.html',
  encapsulation: ViewEncapsulation.None,
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class HomePageSettingsComponent implements OnInit, OnDestroy {
  @ViewChild('drawer') drawer: MatDrawer;
  drawerMode: 'over' | 'side' = 'side';
  drawerOpened: boolean = true;
  panels: any[] = [];
  selectedPanel: string = 'cover';
  private _unsubscribeAll: Subject<any> = new Subject<any>();

  constructor(
    private _changeDetectorRef: ChangeDetectorRef,
    private _fuseMediaWatcherService: FuseMediaWatcherService
  ) { }

  ngOnInit(): void {
    // Setup available panels
    this.panels = [
      {
        id: 'cover',
        icon: 'heroicons_outline:photograph',
        title: 'Cover Items',
        description: 'Manage cover carousels and related image and title'
      },
      {
        id: 'category',
        icon: 'heroicons_outline:view-boards',
        title: 'Category Items',
        description: 'Manage categories and related image, title and discount labels'
      },
      {
        id: 'brand',
        icon: 'heroicons_outline:star',
        title: 'Brand Items',
        description: 'Manage brand logos and related links'
      },
      {
        id: 'topcollection',
        icon: 'heroicons_outline:sparkles',
        title: 'Top Collection Items',
        description: 'Manage top collection section title, subtitle and description'
      },
      {
        id: 'productItems',
        icon: 'heroicons_outline:collection',
        title: 'Product Items',
        description: 'Manage product section title, subtitle and description'
      },
      {
        id: 'specialProducts',
        icon: 'heroicons_outline:badge-check',
        title: 'Special Product Items',
        description: 'Manage special product section title, subtitle and description'
      },
      {
        id: 'strengthFields',
        icon: 'heroicons_outline:fire',
        title: 'Strength Field Items',
        description: 'Manage strength field section logo, title and description'
      },
      {
        id: 'footer',
        icon: 'heroicons_outline:dots-horizontal',
        title: 'Footer Items',
        description: 'Manage footer items and related links'
      }
    ];

    // Subscribe to media changes
    this._fuseMediaWatcherService.onMediaChange$
      .pipe(takeUntil(this._unsubscribeAll))
      .subscribe(({ matchingAliases }) => {

        // Set the drawerMode and drawerOpened
        if (matchingAliases.includes('lg')) {
          this.drawerMode = 'side';
          this.drawerOpened = true;
        }
        else {
          this.drawerMode = 'over';
          this.drawerOpened = false;
        }

        // Mark for check
        this._changeDetectorRef.markForCheck();
      });
  }

  ngOnDestroy(): void {
    // Unsubscribe from all subscriptions
    this._unsubscribeAll.next(null);
    this._unsubscribeAll.complete();
  }

  // Navigate to the panel
  goToPanel(panel: string): void {
    this.selectedPanel = panel;

    // Close the drawer on 'over' mode
    if (this.drawerMode === 'over') {
      this.drawer.close();
    }
  }

  // Get the details of the panel
  getPanelInfo(id: string): any {
    return this.panels.find(panel => panel.id === id);
  }

  // Track by function for ngFor loops
  trackByFn(index: number, item: any): any {
    return item.id || index;
  }

}

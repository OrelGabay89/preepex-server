/* tslint:disable:max-line-length */
import { FuseNavigationItem } from '@fuse/components/navigation';

export const defaultNavigation: FuseNavigationItem[] = [
  {
    id: 'myaccount',
    title: 'My Account',
    type: 'group',
    icon: 'heroicons_outline:user-circle',
    link: '',
    children: [
      {
        id: 'dashboard',
        title: 'Dashboard',
        type: 'basic',
        icon: 'heroicons_outline:desktop-computer',
        link: '/dashboard'
      },
      {
        id: 'orders',
        title: 'Orders',
        type: 'basic',
        icon: 'heroicons_outline:shopping-cart',
        link: '/orders'
      },
      {
        id: 'catalog',
        title: 'Catalog',
        type: 'collapsable',
        icon: 'heroicons_outline:clipboard-list',
        link: '',
        children: [
          {
            id: 'products',
            title: 'Products',
            type: 'basic',
            icon: 'heroicons_outline:collection',
            link: '/products'
          },
          {
            id: 'categories',
            title: 'Categories',
            type: 'basic',
            icon: 'heroicons_outline:view-grid-add',
            link: '/categories'
          },
          {
            id: 'brands',
            title: 'Brands',
            type: 'basic',
            icon: 'heroicons_outline:star',
            link: '/brands'
          },
          {
            id: 'labels',
            title: 'Labels',
            type: 'basic',
            icon: 'heroicons_outline:bookmark',
            link: '/labels',
          },
        ]
      },
      {
        id: 'siteSettings',
        title: 'Site Settings',
        type: 'collapsable',
        icon: 'heroicons_outline:support',
        link: '',
        children: [
          {
            id: 'homePage',
            title: 'Home Page Settings',
            type: 'basic',
            icon: 'heroicons_outline:home',
            link: '/homepage-settings'
          },
          {
            id: 'productPage',
            title: 'Product Page Settings',
            type: 'basic',
            icon: 'heroicons_outline:puzzle',
            link: '/productpage-settings'
          },
          {
            id: 'categoryPage',
            title: 'Category Page Settings',
            type: 'basic',
            icon: 'heroicons_outline:chip',
            link: '/categorypage-settings'
          },
        ]
      },
      {
        id: 'payments',
        title: 'Payments',
        type: 'basic',
        icon: 'heroicons_outline:cash',
        link: '/payments'
      },
      {
        id: 'marketing',
        title: 'Marketing',
        type: 'collapsable',
        icon: 'heroicons_outline:speakerphone',
        link: '',
        children: [
          {
            id: 'discount',
            title: 'Discount',
            type: 'basic',
            icon: 'heroicons_outline:receipt-tax',
            link: '/discount'
          },
          {
            id: 'newsletterSubscribers',
            title: 'Newsletter subscribers',
            type: 'basic',
            icon: 'heroicons_outline:newspaper',
            link: '/newsletter-subscribers'
          },
        ]
      },
      {
        id: 'reports',
        title: 'Reports',
        type: 'basic',
        icon: 'heroicons_outline:document-report',
        link: '/reports',
        disabled: true,
        badge: {
          title: 'Coming Soon!',
          classes: 'px-2 bg-teal-400 text-black rounded'
        }
      },
      {
        id: 'usersDetail',
        title: 'Users',
        type: 'collapsable',
        icon: 'heroicons_outline:users',
        link: '',
        children: [
          {
            id: 'users',
            title: 'Users',
            type: 'basic',
            icon: 'heroicons_outline:user-circle',
            link: '/users'
          },
          {
            id: 'userRoles',
            title: 'User Roles',
            type: 'basic',
            icon: 'heroicons_outline:academic-cap',
            link: '/user-roles'
          },
        ]
      },
      {
        id: 'settings',
        title: 'Settings',
        type: 'basic',
        icon: 'heroicons_outline:cog',
        link: '/settings'
      },

    ]
  },

];

export const compactNavigation: FuseNavigationItem[] = [
  {
    id: 'dashboard',
    title: 'Dashboard',
    type: 'basic',
    icon: 'heroicons_outline:chart-pie',
    link: '/dashboard'
  }
];

export const futuristicNavigation: FuseNavigationItem[] = [
  {
    id: 'dashboard',
    title: 'Dashboard',
    type: 'basic',
    icon: 'heroicons_outline:chart-pie',
    link: '/dashboard'
  }
];

export const horizontalNavigation: FuseNavigationItem[] = [
  {
    id: 'dashboard',
    title: 'Dashboard',
    type: 'basic',
    icon: 'heroicons_outline:chart-pie',
    link: '/dashboard'
  }
];

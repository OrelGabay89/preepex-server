import { Route } from '@angular/router';
import { AuthGuard } from 'app/core/auth/guards/auth.guard';
import { NoAuthGuard } from 'app/core/auth/guards/noAuth.guard';
import { LayoutComponent } from 'app/layout/layout.component';
import { InitialDataResolver } from 'app/app.resolvers';

// @formatter:off
/* eslint-disable max-len */
/* eslint-disable @typescript-eslint/explicit-function-return-type */
export const appRoutes: Route[] = [

    // Redirect empty path to '/dashboard'
    {path: '', pathMatch : 'full', redirectTo: 'dashboard'},

    // Redirect signed in user to the '/dashboard'
    //
    // After the user signs in, the sign in page will redirect the user to the 'signed-in-redirect'
    // path. Below is another redirection for that path to redirect the user to the desired
    // location. This is a small convenience to keep all main routes together here on this file.
    {path: 'signed-in-redirect', pathMatch : 'full', redirectTo: 'dashboard'},

    // Auth routes for guests
    {
        path: '',
        canActivate: [NoAuthGuard],
        canActivateChild: [NoAuthGuard],
        component: LayoutComponent,
        data: {
            layout: 'empty'
        },
        children: [
            {path: 'confirmation-required', loadChildren: () => import('app/modules/auth/confirmation-required/confirmation-required.module').then(m => m.AuthConfirmationRequiredModule)},
            {path: 'forgot-password', loadChildren: () => import('app/modules/auth/forgot-password/forgot-password.module').then(m => m.AuthForgotPasswordModule)},
            {path: 'reset-password', loadChildren: () => import('app/modules/auth/reset-password/reset-password.module').then(m => m.AuthResetPasswordModule)},
            {path: 'sign-in', loadChildren: () => import('app/modules/auth/sign-in/sign-in.module').then(m => m.AuthSignInModule)},
            {path: 'sign-up', loadChildren: () => import('app/modules/auth/sign-up/sign-up.module').then(m => m.AuthSignUpModule)}
        ]
    },

    // Auth routes for authenticated users
    {
        path: '',
        canActivate: [AuthGuard],
        canActivateChild: [AuthGuard],
        component: LayoutComponent,
        data: {
            layout: 'empty'
        },
        children: [
            {path: 'sign-out', loadChildren: () => import('app/modules/auth/sign-out/sign-out.module').then(m => m.AuthSignOutModule)},
            {path: 'unlock-session', loadChildren: () => import('app/modules/auth/unlock-session/unlock-session.module').then(m => m.AuthUnlockSessionModule)}
        ]
    },

    // Landing routes
    {
        path: '',
        component  : LayoutComponent,
        data: {
            layout: 'empty'
        },
        children   : [
            {path: 'home', loadChildren: () => import('app/modules/landing/home/home.module').then(m => m.LandingHomeModule)},
        ]
    },

    // Admin routes
    {
        path       : '',
        canActivate: [AuthGuard],
        canActivateChild: [AuthGuard],
        component  : LayoutComponent,
        resolve    : {
            initialData: InitialDataResolver,
        },
        children: [
            { path: 'dashboard', loadChildren: () => import('app/modules/admin/dashboard/dashboard.module').then(m => m.DashboardModule) },
            { path: 'orders', loadChildren: () => import('app/modules/admin/orders/orders.module').then(m => m.OrdersModule) },
            { path: 'products', loadChildren: () => import('app/modules/admin/products/products.module').then(m => m.ProductsModule) },
            { path: 'categories', loadChildren: () => import('app/modules/admin/categories/categories.module').then(m => m.CategoriesModule) },
            { path: 'brands', loadChildren: () => import('app/modules/admin/brands/brands.module').then(m => m.BrandsModule) },
            { path: 'labels', loadChildren: () => import('app/modules/admin/labels/labels.module').then(m => m.LabelsModule) },
            { path: 'settings', loadChildren: () => import('app/modules/admin/pages/settings/settings.module').then(m => m.SettingsModule) },
            { path: 'users', loadChildren: () => import('app/modules/admin/users/users.module').then(m => m.UsersModule) },
            { path: 'user-roles', loadChildren: () => import('app/modules/admin/user-roles/user-roles.module').then(m => m.UserRolesModule) },
            { path: 'discount', loadChildren: () => import('app/modules/admin/discount/discount.module').then(m => m.DiscountModule) },
            { path: 'homepage-settings', loadChildren: () => import('app/modules/admin/homepage-settings/homepage-settings.module').then(m => m.HomePageSettingsModule) },
            { path: 'productpage-settings', loadChildren: () => import('app/modules/admin/productpage-settings/productpage-settings.module').then(m => m.ProductpageSettingsModule) },
            { path: 'newsletter-subscribers', loadChildren: () => import('app/modules/admin/newsletter/newsletter.module').then(m => m.NewsletterModule) },
        ]
    }
];

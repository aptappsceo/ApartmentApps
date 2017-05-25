import { Routes, RouterModule }  from '@angular/router';
import { Layout } from './layout.component';
// noinspection TypeScriptValidateTypes
const routes: Routes = [
  { path: '', component: Layout, children: [
    { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
    { path: 'dashboard', loadChildren: '../dashboard/dashboard.module#DashboardModule' },
    { path: 'another-page', loadChildren: '../another/another.module#AnotherModule' },
     { path: 'corporations', loadChildren: '../aacore/aacore.module#AACoreModule' },
  ]}
];

export const ROUTES = RouterModule.forChild(routes);

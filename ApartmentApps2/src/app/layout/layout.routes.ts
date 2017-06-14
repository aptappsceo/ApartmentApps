import { Routes, RouterModule }  from '@angular/router';
import { Layout } from './layout.component';
// noinspection TypeScriptValidateTypes
const routes: Routes = [
  { path: '', component: Layout, children: [
    { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
    { path: 'dashboard', loadChildren: '../dashboard/dashboard.module#DashboardModule' },
    { path: 'another-page', loadChildren: '../another/another.module#AnotherModule' },
    { path: 'admin', loadChildren: '../aacore/aacore.module#AACoreModule' },
    { path: 'officer', loadChildren: '../courtesy-officer/courtesy-officer.module#CourtesyOfficerModule' },
    { path: 'maintenance', loadChildren: '../maintenance/maintenance.module#MaintenanceModule' },
  ]}
];

export const ROUTES = RouterModule.forChild(routes);

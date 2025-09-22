import { Routes } from '@angular/router';
import { MedicineListingComponent } from './pages/medicine-listing/medicine-listing.component';
import { NoPageFoundComponent } from './pages/no-page-found/no-page-found.component';
import { FormMedicineRegComponent } from './pages/form-medicine-reg/form-medicine-reg.component';
import { FormUpdateComponent } from './pages/form-update/form-update.component';
import { SearchComponent } from './pages/search/search.component';

export const routes: Routes = [
    {
        path:'',
        redirectTo: 'medicines',
        pathMatch: 'full'
    },
    {
        path:'medicines',
        component: MedicineListingComponent
    },
    {
        path:'search',
        component: SearchComponent
    },
    {
        path:'medicines/edit/:id',
        component: FormUpdateComponent
    },
    {
        path:'form-medicine-registration',
        component: FormMedicineRegComponent
    },    
    {
        path:'**',
        component: NoPageFoundComponent
    },
];

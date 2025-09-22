
import { Component, inject, OnInit } from  '@angular/core';
import { ActivatedRoute, Router, RouterLink } from  '@angular/router';
import { MedicineService } from '../../services/medicine.service';
import { IMedicine } from '../../models/medicine';
import { HttpClientModule } from '@angular/common/http';
import { MedicineListingComponent } from '../medicine-listing/medicine-listing.component';

@Component({
  selector: 'app-search',
  standalone: true,
  imports: [HttpClientModule, RouterLink, MedicineListingComponent],
  templateUrl: './search.component.html',
  styleUrl: './search.component.scss'
})
export class SearchComponent {
  // router= inject(Router)
  // data: any;
  // datam: IMedicine[] = [];
  // medicineService = inject(MedicineService);
  // constructor(private ActivatedRoute: ActivatedRoute) { 
  //   this.ActivatedRoute.queryParams.subscribe(data=>{
  //     this.medicineService.getAllMedicines(data).subscribe({
  //       next: (res: any) => {
  //       this.datam = res;        
  //     },
  //     error: (error: any) => {
  //       console.log(error);        
  //     }
  //   })
      
  //   })
  // }

  
 
}



// constructor(private route: ActivatedRoute, private router: Router) { }
// searchQuery: any
// ngOnInit() {
//   this.route.queryParamMap.subscribe(params => {
//     this.searchQuery = params.get('search');

    
//     // Perform search logic based on query parameters
//     this.performSearch(this.searchQuery);
//   });
// }

// performSearch(searchQuery: string) {
// // Implement search logic here using the provided parameters
// // You can update the component's properties or fetch filtered data from a service
// }

// onSearchSubmit(formValues: any) {
// const queryParams = {
// search: formValues.search
// };

// // Use router navigation to update query parameters
// this.router.navigate([], {
// relativeTo: this.route,
// queryParams: queryParams,
// queryParamsHandling: 'merge'
// });
// }

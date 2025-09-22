import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { NavigationEnd, Router, RouterLink, RouterOutlet } from '@angular/router';
import { MedicineService } from './services/medicine.service';
import { MedicineListingComponent } from './pages/medicine-listing/medicine-listing.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, RouterLink, FormsModule, MedicineListingComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {

  medicineService = inject(MedicineService);
  router= inject(Router)
  
  title = 'frontend';
  activeIndex = 0;
  tradename: string = "";
  data: any;
  
  public isNavbar=true;
  ngAfterViewInit() {  
    this.router.events.subscribe((event) => {
      if (event instanceof NavigationEnd) {   
        if(event.url.includes('form-medicine-registration')){
            this.isNavbar=false;
        }else{
          this.isNavbar=true;
        }
      }
    });
  }

  onSearchSubmit(){
     this.router.navigate(
         ['/search'],
         { queryParams: { tradename: this.tradename } }         
      );   
   }
}

    
   

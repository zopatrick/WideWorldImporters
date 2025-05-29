import { Component, OnInit } from '@angular/core';
import { Country } from '../../models/country.model';
import { CountryService } from '../../services/country.service';

@Component({
  selector: 'app-country',
  templateUrl: './country.component.html',
  styleUrls: ['./country.component.css']
})
export class CountryComponent implements OnInit {
  countries: Country[] = [];
  country: Country = { countryId: 0, countryName: '', continent: '', region: '' };
  isEdit = false;

  constructor(private service: CountryService) { }

  ngOnInit(): void {
    this.loadCountries();
  }

  loadCountries(): void {
    this.service.getAll().subscribe(data => this.countries = data);
  }

  save(): void {
    if (this.isEdit) {
      this.service.update(this.country).subscribe(() => {
        this.loadCountries();
        this.reset();
      });
    } else {
      this.service.create(this.country).subscribe(() => {
        this.loadCountries();
        this.reset();
      });
    }
  }

  edit(c: Country): void {
    this.country = { ...c };
    this.isEdit = true;
  }

  delete(id: number): void {
    if (confirm('Are you sure?')) {
      this.service.delete(id).subscribe(() => this.loadCountries());
    }
  }

  reset(): void {
    this.country = { countryId: 0, countryName: '', continent: '', region: '' };
    this.isEdit = false;
  }
}

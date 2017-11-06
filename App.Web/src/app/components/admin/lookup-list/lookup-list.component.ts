import { Component, OnInit } from '@angular/core';
import { LookupService } from '../../../services/lookup.service';
import { Lookup } from '../../../interfaces/lookup';

@Component({
  selector: 'app-lookup-list',
  templateUrl: './lookup-list.component.html',
  styleUrls: ['./lookup-list.component.css']
})
export class LookupListComponent implements OnInit {
  lookups: Lookup[];

  constructor(private lookupService: LookupService) { }

  ngOnInit() {
    this.lookupService.getAll().subscribe((res) => {
      this.lookups = res.json() as Lookup[];
    });
  }

}

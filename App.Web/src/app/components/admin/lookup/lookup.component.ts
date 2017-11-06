import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { LookupService } from '../../../services/lookup.service';
import { Lookup } from '../../../interfaces/lookup';

@Component({
  selector: 'app-lookup',
  templateUrl: './lookup.component.html',
  styleUrls: ['./lookup.component.css']
})
export class LookupComponent implements OnInit, OnDestroy {
  lookup: Lookup;
  id: number;
  private sub: any;

  constructor(
    private route: ActivatedRoute,
    private lookupService: LookupService
  ) { }

  ngOnInit() {
    this.lookup = {} as Lookup;

    this.sub = this.route.params.subscribe(params => {
        this.id = +params['id']; // (+) converts string 'id' to a number

        // In a real app: dispatch action to load the details here.
        if (this.id) {
          this.lookupService.get(this.id).subscribe((res) => {
            this.lookup = res.json() as Lookup;
          });
        }
    });
  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }

}

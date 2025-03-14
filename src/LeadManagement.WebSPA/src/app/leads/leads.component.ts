import { Component, OnInit } from '@angular/core';
import { Lead, LeadService } from '../lead.service';

@Component({
  selector: 'app-leads',
  templateUrl: './leads.component.html',
  styleUrls: ['./leads.component.css']
})
export class LeadsComponent implements OnInit {
  invitedLeads: Lead[] = [];
  acceptedLeads: Lead[] = [];

  constructor(private leadService: LeadService) {}

  ngOnInit(): void {
    this.loadLeads();
  }

  loadLeads(): void {
    this.leadService.getLeadsByStatus('Invited').subscribe(leads => this.invitedLeads = leads);
    this.leadService.getLeadsByStatus('Accepted').subscribe(leads => this.acceptedLeads = leads);
  }

  acceptLead(id: number): void {
    this.leadService.acceptLead(id).subscribe(() => this.loadLeads());
  }

  declineLead(id: number): void {
    this.leadService.declineLead(id).subscribe(() => this.loadLeads());
  }
}

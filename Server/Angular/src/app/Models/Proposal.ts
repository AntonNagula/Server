export class Proposal {
  proposalId: number;
  name: string;
  userName: string;
  userSurname: string;
  purpose: string;
  amount: number;
  bankAccount: string;
  statusId: number;
}

export enum Statuses {
  Draft = 1,
  Sent = 2,
  Approved = 3
}

export type RequestStatus = "Pending" | "Approved" | "Rejected";

export type RequestItem = {
  id: string;
  title: string;
  submitted_by: string;
  status: RequestStatus;
  created_at: string;
};

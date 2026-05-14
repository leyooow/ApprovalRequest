import type { RequestItem } from "../types";

type Props = {
  item: RequestItem;
  role: "admin" | "user";
  onApprove: (id: string) => void;
  onReject: (id: string) => void;
};

export default function RequestRow({ item, role, onApprove, onReject }: Props) {
  const isPending = item.status === "Pending";

  const statusUI = {
    Pending: (
      <span className="bg-yellow-100 text-yellow-700 px-2 py-1 rounded">
        Pending
      </span>
    ),
    Approved: (
      <span className="bg-green-100 text-green-700 px-2 py-1 rounded">
        Approved
      </span>
    ),
    Rejected: (
      <span className="bg-red-100 text-red-700 px-2 py-1 rounded">
        Rejected
      </span>
    ),
  };

  return (
    <tr className="border-b hover:bg-sky-50">
      <td className="p-4">{item.title}</td>
      <td className="p-4">{item.submitted_by}</td>
      <td className="p-4">{statusUI[item.status]}</td>
      <td className="p-4">
        {new Date(item.created_at).toLocaleDateString()}
      </td>

      <td className="p-4 text-right">
        {isPending && role === "admin" ? (
          <div className="flex gap-2 justify-end">
            <button
              onClick={() => onApprove(item.id)}
              className="bg-green-500 hover:bg-green-600 text-white px-3 py-1 rounded"
            >
              Approve
            </button>

            <button
              onClick={() => onReject(item.id)}
              className="bg-red-500 hover:bg-red-600 text-white px-3 py-1 rounded"
            >
              Reject
            </button>
          </div>
        ) : (
          <span className="text-gray-400 text-sm">—</span>
        )}
      </td>
    </tr>
  );
}

import type { RequestItem } from "../types";
import RequestRow from "./RequestRow";


type Props = {
    items: RequestItem[];
    role: "admin" | "user";
    onApprove: (id: string) => void;
    onReject: (id: string) => void;
};

export default function RequestTable({ items, role, onApprove,onReject  }: Props) {
    if (items.length === 0) {
        return <p className="text-center text-gray-400">No requests yet.</p>;
    }

    return (
        <table className="w-full bg-white rounded-xl shadow">
            <thead className="bg-sky-100 text-left">
                <tr>
                    <th className="p-4">Title</th>
                    <th className="p-4">Submitted By</th>
                    <th className="p-4">Status</th>
                    <th className="p-4">Date</th>
                    <th className="p-4 text-right">Action</th>
                </tr>
            </thead>
            <tbody>
                {items.map((item) => (
                    <RequestRow
                        key={item.id}
                        item={item}
                        role={role}
                        onApprove={onApprove}
                        onReject={onReject}
                    />
                ))}
            </tbody>
        </table>
    );
}
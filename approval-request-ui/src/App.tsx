import { useEffect, useState } from "react";
import type { RequestItem } from "./types";
import Header from "./components/Header";
import RequestTable from "./components/RequestTable";
import Modal from "./components/Modal";
import Toast from "./components/Toast";


export default function App() {
  const [items, setItems] = useState<RequestItem[]>([]);
  const [role, setRole] = useState<"admin" | "user">("admin");
  const [showModal, setShowModal] = useState(false);
  const [toast, setToast] = useState("");

  useEffect(() => {
    const stored = JSON.parse(localStorage.getItem("requests") || "[]");
    setItems(stored);
  }, []);

  const saveItems = (newItems: RequestItem[]) => {
    setItems(newItems);
    localStorage.setItem("requests", JSON.stringify(newItems));
  };

  const createItem = (data: Omit<RequestItem, "id" | "status" | "created_at">) => {
    const newItem: RequestItem = {
      id: Date.now().toString(),
      ...data,
      status: "Pending",
      created_at: new Date().toISOString(),
    };

    saveItems([newItem, ...items]);
    setToast("Request submitted!");
  };

  const approveItem = (id: string) => {
    const updated: RequestItem[] = items.map((item) =>
      item.id === id ? { ...item, status: "Approved" } : item
    );

    saveItems(updated);
    setToast("Approved!");
  };

  const rejectItem = (id: string) => {
    const updated: RequestItem[] = items.map((item) =>
      item.id === id ? { ...item, status: "Rejected" } : item
    );

    saveItems(updated);
    setToast("Rejected!");
  };


  return (
    <div className="min-h-screen bg-gradient-to-br from-blue-50 via-sky-50 to-cyan-50 p-6">
      <Header role={role} setRole={setRole} onNew={() => setShowModal(true)} />

      <RequestTable
        items={items}
        role={role}
        onApprove={approveItem}
        onReject={rejectItem}
      />

      <Modal
        open={showModal}
        onClose={() => setShowModal(false)}
        onSubmit={createItem}
      />

      <Toast message={toast} onClose={() => setToast("")} />
    </div>
  );
}
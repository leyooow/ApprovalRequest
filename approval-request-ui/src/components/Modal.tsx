import { useState } from "react";

type Props = {
  open: boolean;
  onClose: () => void;
  onSubmit: (data: { title: string; submitted_by: string }) => void;
};

export default function Modal({ open, onClose, onSubmit }: Props) {
  const [title, setTitle] = useState("");
  const [submittedBy, setSubmittedBy] = useState("");

  if (!open) return null;

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    onSubmit({ title, submitted_by: submittedBy });
    setTitle("");
    setSubmittedBy("");
    onClose();
  };

  return (
    <div className="fixed inset-0 bg-black/30 flex justify-center items-center">
      <form
        onSubmit={handleSubmit}
        className="bg-white p-6 rounded-xl w-96"
      >
        <h2 className="mb-4 font-bold text-lg">New Request</h2>

        <input
          value={title}
          onChange={(e) => setTitle(e.target.value)}
          placeholder="Title"
          className="w-full mb-3 border p-2 rounded"
        />

        <input
          value={submittedBy}
          onChange={(e) => setSubmittedBy(e.target.value)}
          placeholder="Submitted by"
          className="w-full mb-4 border p-2 rounded"
        />

        <div className="flex gap-2">
          <button className="bg-sky-500 text-white px-4 py-2 rounded w-full">
            Submit
          </button>
          <button
            type="button"
            onClick={onClose}
            className="bg-gray-200 px-4 py-2 rounded w-full"
          >
            Cancel
          </button>
        </div>
      </form>
    </div>
  );
}
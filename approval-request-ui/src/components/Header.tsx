type Props = {
  role: "admin" | "user";
  setRole: (role: "admin" | "user") => void;
  onNew: () => void;
};

export default function Header({ role, setRole, onNew }: Props) {
  return (
    <header className="flex justify-between mb-8">
      <div className="flex gap-4 items-center">
        <h1 className="text-3xl font-bold text-sky-600">
          Approval System
        </h1>

        <select
          value={role}
          onChange={(e) => setRole(e.target.value as "admin" | "user")}
          className="border px-2 py-1 rounded"
        >
          <option value="admin">Admin</option>
          <option value="user">User</option>
        </select>
      </div>

      <button
        onClick={onNew}
        className="bg-sky-500 text-white px-4 py-2 rounded-lg"
      >
        New Request
      </button>
    </header>
  );
}

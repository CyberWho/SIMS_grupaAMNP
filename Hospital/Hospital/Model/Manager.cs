namespace Hospital.Model
{
    public class Manager : RoleDescriptionBase
    {
        private int id;
        public override int howMuchAmIPaid()
        {
            return wrappee.howMuchAmIPaid() + 9999;
        }

        public override string describeMyRole()
        {
            return wrappee.describeMyRole() + "Vi ste menadzer\n";
        }
        public Manager(int id, IRoleDescriptior ird)
        {
            this.wrappee = ird;
            this.id = id;
        }
    }
}
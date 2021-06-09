namespace Hospital.Model
{
    public abstract class RoleDescriptionBase : IRoleDescriptior
    {
        public IRoleDescriptior wrappee;

        public abstract string describeMyRole();
        public abstract int howMuchAmIPaid();
    }
}
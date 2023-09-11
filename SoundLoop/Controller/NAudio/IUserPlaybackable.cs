namespace SoundLoop.Controller.NAudio
{
    internal interface IUserPlaybackable:IPauseable,IStopable
    {
        void AdjustVolume(float volume);
        void Play();
    }
}

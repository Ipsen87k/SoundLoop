namespace SoundLoop.Controller.NAudio
{
    internal interface IUserPlaybackable:IPauseable,IStopable,IReadable
    {
        void AdjustVolume(float volume);
        void Play();
    }
}
